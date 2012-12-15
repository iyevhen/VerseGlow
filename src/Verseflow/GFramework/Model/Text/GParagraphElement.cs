using System;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace VerseFlow.GFramework.Model.Text
{
    /// <summary>
    /// Represents a paragraph in the text.
    /// </summary>
    public class GParagraphElement : GTextElement
    {
        #region Constructor

        public GParagraphElement()
        {
        }

        #endregion

        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case PaddingPropertyKey:
                    return Padding.Empty;
                case WrapPropertyKey:
                    return TextWrap.Word;
                case AlignPropertyKey:
                    return ParagraphAlign.Left;
            }

            return base.GetDefaultPropertyValue(propertyKey);
        }

        #endregion

        #region Protected Overrides

        protected override void ParseAttribute(XmlAttribute attribute)
        {
            switch (attribute.Name.ToLower())
            {
                case PaddingAttributeName:
                    string padding = attribute.Value.Trim();
                    string[] paddingValues = padding.Split(',');

                    Padding newPadding = Padding.Empty;

                    try
                    {
                        //if length is 1 then it indicates all values length
                        //otherwise it is in format (left, top, right, bottom)
                        if (paddingValues.Length == 1)
                        {
                            newPadding = new Padding(int.Parse(paddingValues[0]));
                        }
                        else if(paddingValues.Length == 4)
                        {
                            int left = int.Parse(paddingValues[0]);
                            int top = int.Parse(paddingValues[1]);
                            int right = int.Parse(paddingValues[2]);
                            int bottom = int.Parse(paddingValues[3]);

                            newPadding = new Padding(left, top, right, bottom);
                        }
                    }
                    catch
                    {
                        Debug.WriteLine("Failed to parse padding");
                    }

                    Padding = newPadding;
                    return;
                case WrapAttributeName:
                    try
                    {
                        Wrap = (TextWrap)Enum.Parse(typeof(TextWrap), attribute.Value, true);
                    }
                    catch
                    {
                        Debug.WriteLine("Failed to parse wrap");
                    }
                    return;
                case AlignAttributeName:
                    try
                    {
                        Align = (ParagraphAlign)Enum.Parse(typeof(ParagraphAlign), attribute.Value, true);
                    }
                    catch
                    {
                        Debug.WriteLine("Failed to parse align");
                    }
                    return;
            }

            base.ParseAttribute(attribute);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Name of the mark-up attribute.
        /// </summary>
        public override string TagName
        {
            get
            {
                return GTextDocument.ParagraphNodeName;
            }
        }
        public override bool IsContainer
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// Gets or sets the internal padding of the paragraph.
        /// </summary>
        public Padding Padding
        {
            get
            {
                return (Padding)GetPropertyValue(PaddingPropertyKey);
            }
            set
            {
                if (Padding == value)
                {
                    return;
                }

                SetPropertyValue(PaddingPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the text wrapping for the paragraph.
        /// </summary>
        public TextWrap Wrap
        {
            get
            {
                return (TextWrap)GetPropertyValue(WrapPropertyKey);
            }
            set
            {
                if (Wrap == value)
                {
                    return;
                }

                SetPropertyValue(WrapPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the text align in this paragraph.
        /// </summary>
        public ParagraphAlign Align
        {
            get
            {
                return (ParagraphAlign)GetPropertyValue(AlignPropertyKey);
            }
            set
            {
                if (Align == value)
                {
                    return;
                }

                SetPropertyValue(AlignPropertyKey, value);
            }
        }

        #endregion

        #region Property Constants

        public const int PaddingPropertyKey = 1;
        public const int WrapPropertyKey = PaddingPropertyKey + 1;
        public const int AlignPropertyKey = WrapPropertyKey + 1;

        #endregion

        #region Static

        public const string PaddingAttributeName = "padding";
        public const string WrapAttributeName = "wrap";
        public const string AlignAttributeName = "align";

        #endregion
    }
}
