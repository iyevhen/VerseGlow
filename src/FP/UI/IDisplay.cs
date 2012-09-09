using System;
using System.Drawing;

namespace FreePresenter.UI
{
    public interface IDisplay
    {
        void DrawText(string text);
        void DrawBackground(Image image);
        void DrawBackground(Color color);
		bool FullScreen { get; set; }
    	bool IsActive { get; }
    	
		bool IsPlaying { get; }
    	bool IsPaused { get; }
    	bool IsStoped { get; }

    	event EventHandler ActivationChanged;

        void Activate();
        void Deactivate();
    }
}