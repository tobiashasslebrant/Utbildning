using System;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Utbildning.RhinoMocks.Models;

namespace Utbildning.RhinoMocks
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////normal/////////////
            var database = new ArticleDatabase();
            var website = new WebSite(database){MainHeader = "Normal"};

            var publisher = new Publisher();
            publisher.Render(website);

            
            
            ///////////////stub/////////////
            var stubbedDatabase1 = MockRepository.GenerateStub<IArticleDatabase>();
            stubbedDatabase1.Stub(s => s.GetArticles()).IgnoreArguments()
                .Return(new[]
                            {
                                new Article {Header = "this is from a stub"}
                            });
            var website2 = new WebSite(stubbedDatabase1) { MainHeader = "Stub, articles replaced with test data"};
            publisher.Render(website2);
            
            
            /////////////partial mock, stub Max to 2/////////////
            var mockedDatabase1 = MockRepository.GeneratePartialMock<ArticleDatabase>();
            mockedDatabase1.Stub(s => s.Max).Return(2);
            var website3 = new WebSite(mockedDatabase1) { MainHeader = "Partial mock, stub Max to 2" };
            publisher.Render(website3);

            
            /////////////mock, expect call to GetArticles/////////////
            var mockedDatabase2 = MockRepository.GenerateMock<ArticleDatabase>();
            mockedDatabase2.Expect(a => a.Max).CallOriginalMethod(OriginalCallOptions.CreateExpectation);
            mockedDatabase2.Expect(a => a.GetArticles());
            var website4 = new WebSite(mockedDatabase2) { MainHeader = "Mock, expect call to GetArticles" };
            publisher.Render(website4);


            Console.Read();

        }
    }
}
