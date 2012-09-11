using System;

namespace Utbildning.RhinoMocks.Models
{
    public class Publisher
    {
        public void Render(WebSite website)
        {
            Console.Write(website.ToString());
            foreach (var article in website.Articles)
                Console.Write(article.ToString());
        }
    }
}