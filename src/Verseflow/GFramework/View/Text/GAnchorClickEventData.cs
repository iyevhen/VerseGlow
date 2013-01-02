using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.View.Text
{
    public class GAnchorClickEventData : GEventData
    {
	    public GAnchorClickEventData(string text, string href)
        {
            m_Text = text;
            m_Href = href;
        }

	    /// <summary>
        /// Gets the display text of the clicked anchor.
        /// </summary>
        public string Text
        {
            get
            {
                return m_Text;
            }
        }
        /// <summary>
        /// Gets the Href property of the clicked anchor.
        /// </summary>
        public string Href
        {
            get
            {
                return m_Href;
            }
        }

	    internal string m_Href;
        internal string m_Text;
    }
}
