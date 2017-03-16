using System;

namespace VerseFlow.UI.Controls.cyotek.com.TabList
{
  [Flags]
  public enum TabListPageState
  {
    Normal = 0,
    Hot = 1,
    Selected = 2,
    Focused = 4
  }
}
