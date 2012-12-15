using System;

namespace VerseFlow.GFramework.Events
{
	[Flags]
	public enum EventPropagation
	{
		None = 0,
		Bubble = 1,
		Tunnel = Bubble * 2,
		Both = Bubble | Tunnel,
	}
}