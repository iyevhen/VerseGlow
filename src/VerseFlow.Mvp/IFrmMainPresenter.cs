using VerseFlow.Mvp.Core;

namespace VerseFlow.Mvp
{
	public interface IFrmMainPresenter : IPresenter
	{
		IPresenterCommand OpenBibleCmd { get; }
	}
}