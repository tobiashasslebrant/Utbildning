using System.Collections.Generic;
using System.Linq;

namespace Utbildning.Ninject.Models
{
    public class WebSiteWithDependencies
    {
        public string MainHeader { get; set; }

        public IEnumerable<Article> Articles
        {
            get
            {
                var database = new OracleDatabase("connstring:1222222456");
                var articles = database.ReadAll("Articles").Cast<Article>();
                return articles;
            }
        }

        public override string ToString()
        {
            return string.Format("<<<<<<<<<< {0} >>>>>>>>>>>\r\n",
                                 MainHeader);
        }
    }
}