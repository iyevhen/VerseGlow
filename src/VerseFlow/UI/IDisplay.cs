using System;
using System.Drawing;

namespace VerseFlow.UI
{
    public interface IDisplay : IDisposable
    {
	    string Name { get; }
	    void DrawVerse(string content, string reference);

		Color BackColor { get; set; }
		Image BackgroundImage { get; set; }

		bool FullScreen { get; set; }

		bool IsPlaying { get; }
    	bool IsPaused { get; }
    	bool IsStoped { get; }

    	event EventHandler ActivationChanged;
	    event EventHandler SizeChanged;

		Size Size { get; }

	    void Play();
        void Stop();
        void Pause();
    }
}