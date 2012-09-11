using System;

namespace Utbildning.Ninject.Models
{
    public class Publisher
    {
        public void Render(WebSite website)
        {
            Console.Write(website.ToString());
            foreach (var article in website.Articles)
                Console.Write(article.ToString());
            Console.WriteLine();
        }
        public void Render(WebSiteWithDependencies website)
        {
            Console.Write(website.ToString());
            foreach (var article in website.Articles)
                Console.Write(article.ToString());
            Console.WriteLine();
        }
    }
}