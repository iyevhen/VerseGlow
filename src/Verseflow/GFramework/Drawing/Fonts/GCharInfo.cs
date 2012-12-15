namespace VerseFlow.GFramework.Drawing.Fonts
{
    public struct GCharInfo
    {
        public GCharInfo(char ch, float width, float height)
        {
            Char = ch;
            Width = width;
            Height = height;
        }

        public char Char;
        public float Width;
        public float Height;

        public static readonly GCharInfo Empty = new GCharInfo();
    }
}
