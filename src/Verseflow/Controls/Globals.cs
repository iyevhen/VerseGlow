using VerseFlow.GFramework.Drawing.DeviceContexts;

namespace VerseFlow.Controls
{
    public static class Globals
    {
        #region Constructor

        static Globals()
        {
            GdiPlusDevice = new GGdiPlusDeviceContext();
        }

        #endregion

        #region Fields

        public static readonly GGdiPlusDeviceContext GdiPlusDevice;

        #endregion
    }
}
