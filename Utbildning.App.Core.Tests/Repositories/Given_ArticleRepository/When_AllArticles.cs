using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Utbildning.App.Core.Models;
using Utbildning.App.Core.Tests.Repositories.Given_ArticleRepository;

namespace Given_ArticleRepository
{
    public class When_AllArticles : Arrange_ArticleRepository
    {
        private IEnumerable<Article> _result;

        [SetUp]
        public void Setup()
        {
            _result = SystemUnderTest.AllArticles();
        }

        [Test]
        public void should_be_three_articles()
        {
            Assert.That(_result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void should_keep_unsorted()
        {
            Assert.That(_result.ElementAt(0).Header, Is.EqualTo("header1"));
            Assert.That(_result.ElementAt(1).Header, Is.EqualTo("header3"));
            Assert.That(_result.ElementAt(2).Header, Is.EqualTo("header2"));
        }
    }
}