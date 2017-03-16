using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VerseGlow.Core.Import.BibleQuote
{
    /// <summary>
    /// http://bqt.ru/OpisanieFormataModulejj?v=xqh
    /// </summary>
    public class BqtIni
    {
        public const string INI = "bibleqt.ini";

        private readonly List<BqtBook> books = new List<BqtBook>();
        private readonly Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly string parentFolder;
        private readonly Encoding encoding;
        private string chapterSign;
        private string verseSign;

        public BqtIni(string parentFolder, Encoding encoding, IEnumerable<string> lines)
        {
            if (string.IsNullOrEmpty(parentFolder))
                throw new ArgumentNullException("parentFolder");

            if (encoding == null)
                throw new ArgumentNullException("encoding");

            this.parentFolder = parentFolder;
            this.encoding = encoding;

            BqtBook book = null;

            foreach (string line in lines)
            {
                string li = line.Trim();

                if (string.IsNullOrEmpty(li))
                    continue;

                if (li.StartsWith("//"))
                    continue;

                string[] pair = li.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (pair.Length != 2)
                    continue;

                string key = pair[0].Trim();
                string value = pair[1].Trim();

                if (BqtBook.IsNewBook(key))
                {
                    book = new BqtBook(this);
                    books.Add(book);
                }

                if (book != null && book.Parse(key, value))
                    continue;

                if (values.ContainsKey(key))
                    throw new BqtImportException(string.Format("[{0}] contains dublicated KEY - [{1}]", INI, key));

                values.Add(key, value);
            }
        }

        public IEnumerable<BqtBook> Books
        {
            get { return books.ToArray(); }
        }

        public string ParentFolder
        {
            get { return parentFolder; }
        }

        public string BibleName
        {
            get { return GetString(Tags.BibleName); }
        }

        public string BibleShortName
        {
            get { return GetString(Tags.BibleShortName); }
        }

        public bool IsBible
        {
            get { return GetBool(Tags.Bible); }
        }

        public Encoding Encoding
        {
            get { return encoding; }
        }

        public bool HasOldTestament
        {
            get { return GetBool(Tags.OldTestament); }
        }

        public bool HasChapterZero
        {
            get { return GetBool(Tags.ChapterZero); }
        }

        public bool HasNewTestament
        {
            get { return GetBool(Tags.NewTestament); }
        }

        public bool HasApocrypha
        {
            get { return GetBool(Tags.Apocrypha); }
        }

        public bool IsGreek
        {
            get { return GetBool(Tags.Greek); }
        }

        public string HTMLFilter
        {
            get { return GetString(Tags.HTMLFilter); }
        }

        public string Language
        {
            get { return GetString(Tags.Language); }
        }

        public string Alphabet
        {
            get { return GetString(Tags.Alphabet); }
        }

        public string DesiredFontName
        {
            get { return GetString(Tags.DesiredFontName); }
        }

        public int DesiredFontCharset
        {
            get { return GetInt32(Tags.DesiredFontCharset); }
        }

        public string ChapterSign
        {
            get { return chapterSign ?? (chapterSign = GetString(Tags.ChapterSign)); }
        }

        public string VerseSign
        {
            get { return verseSign ?? (verseSign = GetString(Tags.VerseSign)); }
        }

        public int BookQty
        {
            get { return GetInt32(Tags.BookQty); }
        }

        private bool GetBool(string tag)
        {
            string value;
            return values.TryGetValue(tag, out value)
                   && value.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }

        private int GetInt32(string tag)
        {
            int int32 = 0;
            string value;

            if (!values.TryGetValue(tag, out value))
                return int32;

            Int32.TryParse(value, out int32);
            return int32;
        }

        private string GetString(string tag)
        {
            string value;
            return values.TryGetValue(tag, out value) ? value : null;
        }

        public bool IsChapterLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            return line.IndexOf(ChapterSign, StringComparison.OrdinalIgnoreCase) > -1;
        }

        public bool IsVerseLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            return line.IndexOf(VerseSign, StringComparison.OrdinalIgnoreCase) > -1;
        }

        public string GetVerseLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException("line");

            bool verseStarted = false;
            bool ignore = false;
            var output = new StringBuilder();

            if (line.IndexOf('&') >= 0)
                line = WebUtility.HtmlDecode(line);

            for (int i = 0; i < line.Length; i++)
            {
                char chr = line[i];

                if (!ignore)
                {
                    if (chr == '<' || (chr == '[' && Char.IsDigit(line[i + 1])))
                    {
                        ignore = true;
                    }
                    else
                    {
                        if (!verseStarted)
                            verseStarted = Char.IsLetter(chr) || Char.IsPunctuation(chr);

                        if (verseStarted)
                        {
                            output.Append(chr);
                        }
                    }
                }
                else if (chr == '>' || (chr == ']' && i > 0 && Char.IsDigit(line[i - 1])))
                {
                    ignore = false;
                }
            }



            return output
                       .Replace("     ", " ")
                       .Replace("    ", " ")
                       .Replace("   ", " ")
                       .Replace("  ", " ")
                       .ToString()
                       .TrimEnd();
        }

        static class Tags
        {
            public const string BibleName = "BibleName";
            public const string BibleShortName = "BibleShortName";
            public const string Bible = "Bible";
            public const string OldTestament = "OldTestament";
            public const string NewTestament = "NewTestament";
            public const string Apocrypha = "Apocrypha";
            public const string Greek = "Greek";
            public const string HTMLFilter = "HTMLFilter";
            public const string Language = "Language";
            public const string Alphabet = "Alphabet";
            public const string DesiredFontName = "DesiredFontName";
            public const string DesiredFontCharset = "DesiredFontCharset";
            public const string ChapterSign = "ChapterSign";
            public const string ChapterZero = "ChapterZero";
            public const string VerseSign = "VerseSign";
            public const string BookQty = "BookQty";
        }
    }
}