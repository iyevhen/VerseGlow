using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.Model.Nodes
{
    public interface IGEventListener
    {
        void PreviewEvent(GEventArgs e);
    }
}
