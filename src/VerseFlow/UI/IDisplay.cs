using System;
using System.Drawing;

namespace VerseFlow.UI
{
    public interface IDisplay : IDisposable
    {
		string DisplayText { get; set; }
		Color BackColor { get; set; }
		Image BackgroundImage { get; set; }

		bool FullScreen { get; set; }
		bool IsActive { get; }
		bool IsPlaying { get; }
    	bool IsPaused { get; }
    	bool IsStoped { get; }

    	event EventHandler ActivationChanged;
	    event EventHandler SizeChanged;

		Size Size { get; }

        void Activate();
        void Deactivate();
    }
}