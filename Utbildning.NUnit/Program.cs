using System;
using Utbildning.NUnit.Models;

namespace Utbildning.NUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            var website = new WebSite
                              {
                                  MainHeader = "Dagens Blaska" ,
                                  Articles = new[]
                                                 {
                                                     new Article
                                                         {
                                                             Header = "Äntligen !!!  ",
                                                             MainBody = "Kungen avgår",
                                                             PublishedDate = new DateTime(2011, 1, 1, 12, 0, 0)
                                                         },
                                                     new Article
                                                         {
                                                             Header = "Kicki erkänner",
                                                             MainBody = "Jag är beroende av säl-späck",
                                                             PublishedDate = new DateTime(2011, 1, 5, 11, 30, 0)
                                                         },
                                                     new Article
                                                         {
                                                             Header = "Svar på tal   ",
                                                             MainBody = "Dumsnut, Fredrik R talar ut om Stefan L",
                                                             PublishedDate = new DateTime(2011, 1, 2, 12, 5, 0)
                                                         }
                                                             
                                                 }
                              };

            
            website.SortArticlesByDate();

            var publisher = new Publisher();
            publisher.Render(website);

            Console.Read();
        }
    }
}
