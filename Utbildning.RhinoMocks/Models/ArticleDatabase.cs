using System;
using System.Collections.Generic;
using System.Linq;

namespace Utbildning.RhinoMocks.Models
{
    public interface IArticleDatabase
    {
        IEnumerable<Article> GetArticles();
    }

    public class ArticleDatabase : IArticleDatabase
    {
        public virtual int Max { get { return 10; } }
        public IEnumerable<Article> GetArticles()
        {
            return new []
                {
                    new Article{Header = "header1",MainBody = "mainbody1", PublishedDate = new DateTime(2001,1,1)},
                    new Article{Header = "header2",MainBody = "mainbody2", PublishedDate = new DateTime(2001,1,2)},
                    new Article{Header = "header3",MainBody = "mainbody3", PublishedDate = new DateTime(2001,1,3)},
                }.Take(Max);
            
        }
    }
}