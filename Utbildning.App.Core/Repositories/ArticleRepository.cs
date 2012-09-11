using System.Collections.Generic;
using System.Linq;
using Utbildning.App.Core.DB;
using Utbildning.App.Core.Models;

namespace Utbildning.App.Core.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> AllArticles();
        IEnumerable<Article> PublishedArticles();
        void DeleteAll();
        void Create(Article[] articles);
    }

    public class ArticleRepository : IArticleRepository
    {
        private readonly IDatabase<Article> _database;
        public ArticleRepository(){}
        public ArticleRepository(IDatabase<Article> database)
        {
            _database = database;
        }

        public IEnumerable<Article> AllArticles()
        {
            return _database.ReadAll("Article").ToArray();
        }

        public IEnumerable<Article> PublishedArticles()
        {
            return AllArticles().Where(w => w.PublishedDate != null);
        }

        public void DeleteAll()
        {
            _database.DeleteAll("Article");
        }

        public void Create(Article[] articles)
        {
            _database.Create(articles, "Article");
        }
    }
}