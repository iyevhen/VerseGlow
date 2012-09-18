using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Data;

namespace PointLightDemo
{
    public class PointLightEffect : ShaderEffect
    {
        #region Fields

        private static PixelShader _pixelShader = new PixelShader();

        #endregion

        #region Constructors

        static PointLightEffect()
        {
            _pixelShader.UriSource = Global.MakePackUri("PointLight.ps");
        }

        public PointLightEffect()
        {
            this.PixelShader = _pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(FillColorProperty);
            UpdateShaderValue(Light1PositionProperty);
            UpdateShaderValue(Light1ColorProperty);
            UpdateShaderValue(Light2PositionProperty);
            UpdateShaderValue(Light2ColorProperty);
        }

        #endregion

        #region Dependency Properties
        
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PointLightEffect), 0);

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register("FillColor", typeof(Color), typeof(PointLightEffect),
                    new UIPropertyMetadata(PixelShaderConstantCallback(0)));

        public Point Light1Position
        {
            get { return (Point)GetValue(Light1PositionProperty); }
            set { SetValue(Light1PositionProperty, value); }
        }

        public static readonly DependencyProperty Light1PositionProperty =
            DependencyProperty.Register("Light1Position", typeof(Point), typeof(PointLightEffect),
                    new UIPropertyMetadata(PixelShaderConstantCallback(1)));

        public Color Light1Color
        {
            get { return (Color)GetValue(Light1ColorProperty); }
            set { SetValue(Light1ColorProperty, value); }
        }

        public static readonly DependencyProperty Light1ColorProperty =
            DependencyProperty.Register("Light1Color", typeof(Color), typeof(PointLightEffect),
                    new UIPropertyMetadata(PixelShaderConstantCallback(2)));

        public Point Light2Position
        {
            get { return (Point)GetValue(Light2PositionProperty); }
            set { SetValue(Light2PositionProperty, value); }
        }

        public static readonly DependencyProperty Light2PositionProperty =
            DependencyProperty.Register("Light2Position", typeof(Point), typeof(PointLightEffect),
                    new UIPropertyMetadata(PixelShaderConstantCallback(3)));

        public Color Light2Color
        {
            get { return (Color)GetValue(Light2ColorProperty); }
            set { SetValue(Light2ColorProperty, value); }
        }

        public static readonly DependencyProperty Light2ColorProperty =
            DependencyProperty.Register("Light2Color", typeof(Color), typeof(PointLightEffect),
                    new UIPropertyMetadata(PixelShaderConstantCallback(4)));

        #endregion
    }
}
