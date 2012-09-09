using FreePresenter.Convertion;
using FreePresenter.Core;

namespace FreePresenter.UI
{
	public static partial class IoC
	{
		static partial void Initialize()
		{
			Register<ITextFactory, TextFactory>();
			Register<ObjectConverter<Bible, FlatFile<FlatBibleLine>>, FlatBibleConverter>();
		}
	}
}