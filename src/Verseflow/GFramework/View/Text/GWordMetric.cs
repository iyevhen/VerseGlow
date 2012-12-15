using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.GFramework.View.Text
{
    public class GWordMetric
    {
        /// <summary>
        /// The smallest rectangle that completely enclose the word.
        /// </summary>
        public SizeF BlackBox;
        /// <summary>
        /// The measured size of the word.
        /// </summary>
        public SizeF Size;
        /// <summary>
        /// The internal padding, applied by the device when rendering this word
        /// </summary>
        public Padding Padding;
    }
}
