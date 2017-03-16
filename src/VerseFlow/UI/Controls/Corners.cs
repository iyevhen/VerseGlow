﻿using System;

namespace VerseGlow.UI.Controls
{
	[Flags]
	public enum Corners
	{
		None = 0,
		TopLeft = 1,
		TopRight = 2,
		BottomLeft = 4,
		BottomRight = 8,
		All = TopLeft | TopRight | BottomLeft | BottomRight
	}
}