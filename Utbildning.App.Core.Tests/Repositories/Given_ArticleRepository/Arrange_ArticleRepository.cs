using System;
using NUnit.Framework;
using Rhino.Mocks;
using Utbildning.App.Core.DB;
using Utbildning.App.Core.Models;
using Utbildning.App.Core.Repositories;

namespace Utbildning.App.Core.Tests.Repositories.Given_ArticleRepository
{

    public abstract class Arrange_ArticleRepository : TestBase<ArticleRepository>
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var stubDatabase = Stub<IDatabase<Article>>();
            stubDatabase.Stub(s => s.ReadAll("Article")).Return(new[]
                {
                    new Article(){Header = "header1", PublishedDate = null},
                    new Article(){Header = "header3",PublishedDate = new DateTime(2000, 1, 3)},
                    new Article(){Header = "header2",PublishedDate =new DateTime(2000, 1, 2)}
                });
        }
    }
}


