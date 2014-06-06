using VerseFlow.Mvp.Core;

namespace VerseFlow.Mvp.Presenters
{
	public class FrmMainPresenter : PresenterBase<IFrmMainView>, IFrmMainPresenter
	{
		public FrmMainPresenter()
		{
			var build = new PresenterCommandBuilder(this);
			OpenBibleCmd = build.For(() => OpenBible());
		}

		protected override void OnViewConnected(IFrmMainView v)
		{
			base.OnViewConnected(v);

			v.SetMenuItem();
		}

		

		public IPresenterCommand OpenBibleCmd { get; private set; }

		void OpenBible()
		{
		}
	}
}