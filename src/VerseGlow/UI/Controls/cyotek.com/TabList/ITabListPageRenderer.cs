using System.Drawing;

namespace VerseFlow.UI.Controls.cyotek.com.TabList
{
  public interface ITabListPageRenderer
  {
    #region  Private Methods

    void RenderHeader(Graphics g, TabListPage page, TabListPageState state);

    #endregion  Private Methods
  }
}
