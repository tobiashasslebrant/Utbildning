using System.Collections.Generic;
using System.Linq;

namespace Utbildning.NUnit.Models
{
    public class WebSite
    {
        public string MainHeader { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        public void SortArticlesByDate()
        {
            Articles = Articles.OrderByDescending(o => o.PublishedDate);
        }

        public override string ToString()
        {
            return string.Format("<<<<<<<<<< {0} >>>>>>>>>>>\r\n",MainHeader);
        }
    }
}