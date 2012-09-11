using System.Collections.Generic;

namespace Utbildning.RhinoMocks.Models
{
    public class WebSite
    {
        private readonly IArticleDatabase _articleDatabase;

        public WebSite(IArticleDatabase articleDatabase)
        {
            _articleDatabase = articleDatabase;
        }

        public string MainHeader { get; set; }
        public IEnumerable<Article> Articles 
        { 
            get 
            {
                return _articleDatabase.GetArticles(); 
            }
        }

        public override string ToString()
        {
            return string.Format("\r\n<<<<<<<<<< {0} >>>>>>>>>>>\r\n",
                                 MainHeader);
        }
    }
}