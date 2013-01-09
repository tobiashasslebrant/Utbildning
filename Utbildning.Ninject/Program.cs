using System;
using Ninject;
using Utbildning.Ninject.Models;

namespace Utbildning.Ninject
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();
            
            //Utan Ninject och med dependencies
            var websiteWithDependencies = new WebSiteWithDependencies {MainHeader = "Utan Ninject och med dependencies"};
            publisher.Render(websiteWithDependencies);

            
            //Utan Ninject fast med konstruktorer
            var dataBase = new OracleDatabase("connectionstring:123.456.789");
            var articleRepository = new ArticleRepository(dataBase);
            var webSite = new WebSite(articleRepository) {MainHeader = "Utan Ninject fast med konstruktorer"};
            publisher.Render(webSite);

            
            //Med Ninject
            var kernel = new StandardKernel();
            kernel.Bind<IDatabase>().ToMethod(m => new OracleDatabase("connectionstring:123.456.789"));
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();

            var ninjectWebsite = kernel.Get<WebSite>();
            ninjectWebsite.MainHeader = "Med Ninject";
            publisher.Render(ninjectWebsite);

            Console.Read();
        }
    }
}
