using System;
using System.Web.Mvc;
using Utbildning.App.Core.Models;
using Utbildning.App.Core.Repositories;

namespace Utbildning.App.Web.Controllers
{
    public class TestDataController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public TestDataController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void ReCreate()
        {
            _articleRepository.DeleteAll();
            _articleRepository.Create( new[]
            {
                new Article{Header = "Kungen avgår", MainBody="Enligt källa vill den numera föredetta kungen hellre vara en normal svensson.", PublishedDate = new DateTime(2012,2,3)},
                new Article{Header = "Lill-Babs ny stadsminister", MainBody="Citat Lill-Babs: Ser det som en naturlig utveckling, då jag har haft nära kontakt med svenska folket i hela mitt liv.", PublishedDate = new DateTime(2012,2,7)},
                new Article{Header = "Vem blir Fattig?", MainBody="Ny show där miljonärer ställer upp och där den som blir sist får skänka hela sin förmögenhet till tillväxtverket", PublishedDate = new DateTime(2012,2,6)}
            });
        }
    }
}
