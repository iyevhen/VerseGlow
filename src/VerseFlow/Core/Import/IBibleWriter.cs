using System;

namespace VerseFlow.Core.Import
{
	public interface IBibleWriter : IDisposable
	{
		IBible Write(IBibleImportAdapter adapter);
	}
}