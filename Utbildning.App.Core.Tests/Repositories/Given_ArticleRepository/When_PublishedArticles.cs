using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Utbildning.App.Core.Models;

namespace Utbildning.App.Core.Tests.Repositories.Given_ArticleRepository
{
    public class When_PublishedArticles : Arrange_ArticleRepository
    {
        private IEnumerable<Article> _result;

        [SetUp]
        public void Setup()
        {
            _result = SystemUnderTest.PublishedArticles();
        }

        [Test]
        public void should_be_two_articles()
        {
            Assert.That(_result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void should_return_all_that_have_a_publish_date()
        {
            Assert.That(_result.Select(s => s.PublishedDate), Has.All.Not.Null);
        }

        //TODO: add sorting by date

    }
}