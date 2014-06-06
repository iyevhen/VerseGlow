using VerseFlow.Mvp.Core;

namespace VerseFlow.Mvp
{
	public interface IFrmMainView : IView
	{
		void AddChildView(IView view);
		void RemoveChildView(IView view);
	}
}