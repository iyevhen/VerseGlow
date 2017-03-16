using System;

namespace VerseGlow.Core.Import
{
	public interface IBibleWriter : IDisposable
	{
		IBible Write(IBibleImportAdapter adapter);
	}
}