namespace VerseFlow.GFramework.Drawing.Fonts
{
    public struct GKerningPair
    {
        public char Char1;
        public char Char2;
        public float Kerning;

        public override bool Equals(object obj)
        {
            GKerningPair pair = (GKerningPair)obj;
            return Char1 == pair.Char1 && Char2 == pair.Char2 && Kerning == pair.Kerning;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
