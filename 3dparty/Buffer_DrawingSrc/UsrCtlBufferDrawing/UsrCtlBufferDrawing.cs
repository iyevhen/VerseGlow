using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BufferDrawing
{
    public partial class UsrCtlBufferDrawing : UserControl
    {
        //Variables that change the image
        private Color m_ColorBackGround;
        private Color m_ColorRectangle;
        private int m_dotwidth;

        public bool uselayers;
        public TimeSpan timeused;
        public long paintiterations;

        enum TypeOfChange
        {
            TChangeBackGround,
            TChangeRectangles,
            TChangeDotWidth,
            TChangeSelCircle,
            TChangeNone,
        };
        
        const int NumLayers = 4;
        const int NumPoints = 5;
        TypeOfChange vartchange;

        public int dotwidth
        {
            get
            {
                return m_dotwidth;
            }
            set
            {
                m_dotwidth = value;
                vartchange = TypeOfChange.TChangeDotWidth;
                Invalidate();
            }
        }
        public Color ColorBackGround
        {
            get
            {
                return m_ColorBackGround;
            }
            set
            {
                m_ColorBackGround = value;
                vartchange = TypeOfChange.TChangeBackGround;
                Invalidate();
            }
        }
        public Color ColorRectangle
        {
            get
            {
                return m_ColorRectangle;
            }
            set
            {
                m_ColorRectangle = value;
                vartchange = TypeOfChange.TChangeRectangles;
                Invalidate();
            }
        }

        BufferedGraphics[] buffergraphs;

        Point[] dots;
        Boolean[] selecpto;
        Boolean ChangeSelection;
        
        private Pen pendotborder;
        private Pen pencircle;

        private SolidBrush brushdotnormal;
        private SolidBrush brushdotselected;
        
        private SolidBrush brushcircle;

        private Point mousestartpoint;
        private Point mousecurrent;

        public UsrCtlBufferDrawing()
        {
            buffergraphs = new BufferedGraphics[NumLayers];
            InitializeComponent();

            ColorBackGround = Color.Black;
            ColorRectangle = Color.Green;

            pendotborder = new Pen(Color.Black);
            brushdotnormal = new SolidBrush(Color.Red);
            brushdotselected = new SolidBrush(Color.Blue);
            pencircle = new Pen(Color.Violet,2);
            brushcircle = new SolidBrush(Color.Violet);
            
            InitArray();
            dotwidth = 3;
            
            vartchange = TypeOfChange.TChangeBackGround;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            SetStyle(ControlStyles.Opaque, true);
            mousestartpoint.X = -1;

            InitIter();
        }
        private void InitArray()
        {
            dots = new Point[NumPoints];
            dots[0].X = 20;
            dots[0].Y = 32;
            dots[1].X = 45;
            dots[1].Y = 80;
            dots[2].X = 178;
            dots[2].Y = 254;
            dots[3].X = 21;
            dots[3].Y = 365;
            dots[4].X = 180;
            dots[4].Y = 180;

            selecpto = new Boolean[NumPoints];
            ResetSelectPtos();
        }
        void ResetSelectPtos()
        {
            for (int i = 0; i < NumPoints; i++)
                selecpto[i] = false;
        }
        private void UsrCtlBufferDrawing_Paint(Object sender, PaintEventArgs e)
        {
            if (e.ClipRectangle.Width == 0) return;
            DateTime t1, t2;
            paintiterations++;
            if (!uselayers)
            {
                t1 = System.DateTime.Now;
                DrawFirstLayer(buffergraphs[0].Graphics, e.ClipRectangle);
                DrawSecondLayer(buffergraphs[0].Graphics, e.ClipRectangle);
                DrawThirdLayer(buffergraphs[0].Graphics, e.ClipRectangle);
                DrawFourthLayer(buffergraphs[0].Graphics, e.ClipRectangle);
                buffergraphs[0].Render(e.Graphics);
                t2 = System.DateTime.Now;
                timeused += (t2 - t1);
                return;
            }
            t1 = System.DateTime.Now;
            if (vartchange == TypeOfChange.TChangeBackGround)
            {
                DrawFirstLayer(buffergraphs[(int)TypeOfChange.TChangeBackGround].Graphics, e.ClipRectangle);
                buffergraphs[(int)TypeOfChange.TChangeBackGround].Render(buffergraphs[(int)TypeOfChange.TChangeRectangles].Graphics);
            }
            if (vartchange == TypeOfChange.TChangeRectangles)
                buffergraphs[(int)TypeOfChange.TChangeBackGround].Render(buffergraphs[(int)TypeOfChange.TChangeRectangles].Graphics);

            if (vartchange == TypeOfChange.TChangeBackGround || vartchange == TypeOfChange.TChangeRectangles)
            {
                DrawSecondLayer(buffergraphs[(int)TypeOfChange.TChangeRectangles].Graphics, e.ClipRectangle);
                buffergraphs[(int)TypeOfChange.TChangeRectangles].Render(buffergraphs[(int)TypeOfChange.TChangeDotWidth].Graphics);
            }
            if (vartchange == TypeOfChange.TChangeDotWidth)
                buffergraphs[(int)TypeOfChange.TChangeRectangles].Render(buffergraphs[(int)TypeOfChange.TChangeDotWidth].Graphics);

            if (vartchange == TypeOfChange.TChangeBackGround || vartchange == TypeOfChange.TChangeRectangles || vartchange == TypeOfChange.TChangeDotWidth)
            {
                DrawThirdLayer(buffergraphs[(int)TypeOfChange.TChangeDotWidth].Graphics, e.ClipRectangle);
                buffergraphs[(int)TypeOfChange.TChangeDotWidth].Render(buffergraphs[(int)TypeOfChange.TChangeSelCircle].Graphics);
            }
            if (vartchange == TypeOfChange.TChangeSelCircle)
                buffergraphs[(int)TypeOfChange.TChangeDotWidth].Render(buffergraphs[(int)TypeOfChange.TChangeSelCircle].Graphics);

            if (vartchange != TypeOfChange.TChangeNone)
            {
                DrawFourthLayer(buffergraphs[(int)TypeOfChange.TChangeSelCircle].Graphics, e.ClipRectangle);
                buffergraphs[(int)TypeOfChange.TChangeSelCircle].Render(e.Graphics);
                //buffergraphs[(int)TypeOfChange.TChangeSelCircle].Render(Graphics.FromHwnd(this.Handle));
            }
            if (vartchange == TypeOfChange.TChangeNone)
                buffergraphs[(int)TypeOfChange.TChangeSelCircle].Render(e.Graphics);
                //buffergraphs[(int)TypeOfChange.TChangeSelCircle].Render(Graphics.FromHwnd(this.Handle));
            t2 = System.DateTime.Now;
            timeused += (t2 - t1);
            vartchange = TypeOfChange.TChangeNone;
        }
        private void DrawFirstLayer(Graphics g, Rectangle r)
        {
            LinearGradientBrush brush;
            brush = new LinearGradientBrush(r, ColorBackGround,
                           Color.White, LinearGradientMode.Horizontal);

            Blend blend = new Blend(9);
            blend.Positions[0] = 0.0f;
            blend.Positions[1] = 0.125f;
            blend.Positions[2] = 0.25f;
            blend.Positions[3] = 0.375f;
            blend.Positions[4] = 0.5f;
            blend.Positions[5] = 0.625f;
            blend.Positions[6] = 0.75f;
            blend.Positions[7] = 0.875f;
            blend.Positions[8] = 1.0f;
            blend.Factors[0] = 0.0f;
            blend.Factors[1] = 0.2f;
            blend.Factors[2] = 0.4f;
            blend.Factors[3] = 0.6f;
            blend.Factors[4] = 0.7f;
            blend.Factors[5] = 0.8f;
            blend.Factors[6] = 0.9f;
            blend.Factors[7] = 0.95f;
            blend.Factors[8] = 1.0f;
            brush.Blend = blend;

            /*Pen p = new Pen(ColorBackGround);

            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, 0, 0, r.Width, r.Height);

            int iterTo = Convert.ToInt32(r.Height / 3);
            for (int i = 1; i <= iterTo; i++)
            {
                g.DrawLine(p, 0, 3 * i, r.Width, 3 * i);
            }

            iterTo = Convert.ToInt32(r.Width / 3);
            for (int i = 1; i <= iterTo; i++)
            {
                g.DrawLine(p, 3 * i, 0, 3 * i, r.Height);
            }*/
            g.FillRectangle(brush, r);

        }
        private void DrawSecondLayer(Graphics g, Rectangle r)
        {
            string text;
            Font textFont = new Font("Arial", 9 + dotwidth * 2);

            LinearGradientBrush textBrush;

            Brush b = new SolidBrush(ColorRectangle);
            int fromY = 0; int fromX;
            while (fromY <= r.Height)
            {
                fromX = 0;
                while (fromX <= r.Width)
                {
                    text = "test: " + fromX.ToString();
                    SizeF textSize = g.MeasureString(text, textFont);
                    PointF textLocation = new PointF(fromX, fromY);
                    RectangleF textArea = new RectangleF(textLocation, textSize);
                    textBrush = new LinearGradientBrush(textArea, Color.Black,
                               Color.White, LinearGradientMode.Horizontal);
                    g.DrawString(text, textFont, textBrush, textArea);
                    fromX += 100;
                }
                fromY += 20;
            }
        }
        private void DrawThirdLayer(Graphics g, Rectangle r)
        {
            int xpos, ypos;
            int dwith = dotwidth*2;
            for (int i=0;i<dots.Length;i++)
            {
                xpos = dots[i].X - dotwidth;
                ypos = dots[i].Y - dotwidth;
                if (selecpto[i])
                    g.FillEllipse(brushdotselected, xpos, ypos, dwith, dwith);
                else
                    g.FillEllipse(brushdotnormal, xpos, ypos, dwith, dwith);
                g.DrawEllipse(pendotborder, xpos, ypos, dwith,dwith);
            }
        }
        private void DrawFourthLayer(Graphics g, Rectangle r)
        {
            if (mousestartpoint.X == -1) return;

            int cx = mousecurrent.X - mousestartpoint.X; if (cx < 0) cx *= -1;
            int cy = mousecurrent.Y - mousestartpoint.Y; if (cy < 0) cy *= -1;
        	int dist = Convert.ToInt32(Math.Sqrt(Math.Pow(cx, 2) + Math.Pow(cy, 2)));
	           
    		g.DrawEllipse(pencircle, mousestartpoint.X - dist,mousestartpoint.Y - dist, dist*2,dist*2);
		    g.FillEllipse(brushcircle, mousestartpoint.X - 4, mousestartpoint.Y - 4, 8,8);
        }
        private void UsrCtlBufferDrawing_Resize(Object sender, EventArgs e)
        {
            BufferedGraphicsContext context;

		    context = BufferedGraphicsManager.Current;
		    context.MaximumBuffer = new System.Drawing.Size(this.Width + 1, this.Height + 1 );
            for (int i = 0; i < NumLayers; i++)
                buffergraphs[i] = context.Allocate(this.CreateGraphics(), new System.Drawing.Rectangle(0,0, this.Width, this.Height ));
            vartchange = TypeOfChange.TChangeBackGround;
            Invalidate();
        }
        private void UsrCtlBufferDrawing_MouseDown(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousestartpoint.X = e.X;
                mousestartpoint.Y = e.Y;
                vartchange = TypeOfChange.TChangeSelCircle;
                Invalidate();
            }
        }
        private void UsrCtlBufferDrawing_MouseUp(Object sender, MouseEventArgs e)
        {
            if (mousestartpoint.X != -1)
            {
                ResetSelectPtos();
                vartchange = TypeOfChange.TChangeDotWidth;
                mousestartpoint.X = -1;
                Invalidate();
            }
        }
        private void UsrCtlBufferDrawing_Move(Object sender, MouseEventArgs e)
        {
            mousecurrent.X = e.X;
            mousecurrent.Y = e.Y;
            if (mousestartpoint.X != -1)
            {
                vartchange = TypeOfChange.TChangeSelCircle;
                VerifyPoints();
                Invalidate();
            }
        }
        private double distance(int P1X, int P1Y, int P2X, int P2Y)
        {
            double cdatox = P1X - P2X; if (cdatox < 0) cdatox *= -1;
            double cdatoy = P1Y - P2Y; if (cdatoy < 0) cdatoy *= -1;
            return Math.Sqrt(Math.Pow(cdatox, 2) + Math.Pow(cdatoy, 2));
        }
        private void VerifyPoints()
        {
            ChangeSelection = false;
            Boolean selpoint;
            for (int i = 0; i < NumPoints; i++)
            {
                double dist1 = distance(mousecurrent.X, mousecurrent.Y, mousestartpoint.X, mousestartpoint.Y);
                double dist2 = distance(dots[i].X, dots[i].Y, mousestartpoint.X, mousestartpoint.Y);
                if (dist2 <= dist1)
                    selpoint = true;
                else
                    selpoint = false;

                if (selecpto[i] && !selpoint)
                    ChangeSelection = true;
                if (!selecpto[i] && selpoint)
                    ChangeSelection = true;

                selecpto[i] = selpoint;
            }
            if (ChangeSelection)
                vartchange = TypeOfChange.TChangeDotWidth;
        }
        private void UsrCtlBufferDrawingDestroy(Object sender, EventArgs e)
        {
            for (int i = 0; i < NumLayers; i++)
            {
                if (buffergraphs[i] != null)
                    buffergraphs[i].Dispose();
            }
        }
        public void InitIter()
        {
            paintiterations = 0;
            timeused = new TimeSpan(0);
        }
    }
}
