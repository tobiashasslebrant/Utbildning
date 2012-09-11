using System.Collections.Generic;

namespace Utbildning.Ninject.Models
{
    public class WebSite
    {
        private readonly IArticleRepository _articleRepository;

        public WebSite(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public string MainHeader { get; set; }

        public IEnumerable<Article> Articles
        {
            get { return _articleRepository.GetArticles();}
        }

        public override string ToString()
        {
            return string.Format("<<<<<<<<<< {0} >>>>>>>>>>>\r\n",
                                 MainHeader);
        }
    }
}