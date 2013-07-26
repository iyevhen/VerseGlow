using System.Drawing;

namespace VerseFlow.UI.Controls.cyotek.com.TabList
{
  public abstract class TabListPageRenderer
    : ITabListPageRenderer
  {
    #region  Public Class Properties

    public static ITabListPageRenderer DefaultRenderer { get; set; }

    #endregion  Public Class Properties

    #region  Public Abstract Methods

    public abstract void RenderHeader(Graphics g, TabListPage page, TabListPageState state);

    #endregion  Public Abstract Methods
  }
}
