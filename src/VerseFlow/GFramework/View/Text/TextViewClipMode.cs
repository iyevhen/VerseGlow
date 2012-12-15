namespace VerseFlow.GFramework.View.Text
{
    public enum TextViewClipMode
    {
        /// <summary>
        /// No clipping
        /// </summary>
        None,
        /// <summary>
        /// Clipping is applied per paint bounds.
        /// Text lines may become partially visible
        /// </summary>
        Bounds,
        /// <summary>
        /// Clipping is performed per line.
        /// If a line is not painted if does not fit into the paint bounds.
        /// </summary>
        Line,
    }
}
