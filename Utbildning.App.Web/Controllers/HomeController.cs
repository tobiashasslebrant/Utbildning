using System.Linq;
using System.Web.Mvc;
using Utbildning.App.Core.Repositories;

namespace Utbildning.App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ActionResult Index()
        {
            var articles = _articleRepository.PublishedArticles();
            var list = articles.ToArray();

            return View(list);
        }
    }
}
