using System.Collections.Generic;
using System.Linq;

namespace Utbildning.Ninject.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();
    }

    public class ArticleRepository : IArticleRepository
    {
        private readonly IDatabase _database;

        public ArticleRepository(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _database.ReadAll("Articles").Cast<Article>();
        }
    }
}