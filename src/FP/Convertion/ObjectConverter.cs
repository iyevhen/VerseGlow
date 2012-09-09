namespace FreePresenter.Convertion
{
	public abstract class ObjectConverter<TIn, TOut>
	{
		public abstract TIn Convert(TOut flatFile);
		public abstract TOut Convert(TIn @in);
	}
}