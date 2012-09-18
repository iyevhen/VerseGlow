using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PointLightDemo
{
    public class BlendEffect : ShaderEffect
    {
        #region Fields

        private static PixelShader _pixelShader = new PixelShader();

        #endregion

        #region Constructors

        static BlendEffect()
        {
            _pixelShader.UriSource = Global.MakePackUri("Blend.ps");
        }

        public BlendEffect()
        {
            PixelShader = _pixelShader;

            UpdateShaderValue(Input1Property);
            UpdateShaderValue(Input2Property);
        }

        #endregion

        #region Dependency Properties

        public Brush Input1
        {
            get { return (Brush)GetValue(Input1Property); }
            set { SetValue(Input1Property, value); }
        }

        public static readonly DependencyProperty Input1Property =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input1", typeof(BlendEffect), 0);

        public Brush Input2
        {
            get { return (Brush)GetValue(Input2Property); }
            set { SetValue(Input2Property, value); }
        }

        public static readonly DependencyProperty Input2Property =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input2", typeof(BlendEffect), 1);

        #endregion
    }
}
