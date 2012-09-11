using System;

namespace Utbildning.NUnit.Models
{
    public class Article
    {
        public string Header { get; set; }
        public string MainBody { get; set; }
        public DateTime PublishedDate { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}\t{2}\r\n", PublishedDate.ToString("yyyy/MM/dd"), Header, MainBody);
        }
    }
}
