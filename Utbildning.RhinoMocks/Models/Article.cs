using System;

namespace Utbildning.RhinoMocks.Models
{
    public class Article
    {
        public string Header { get; set; }
        public string MainBody { get; set; }
        public DateTime PublishedDate { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\r\n", 
                Header, MainBody);
        }
    }
}
