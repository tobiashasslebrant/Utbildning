using System;
using System.Linq;
using NUnit.Framework;
using Utbildning.NUnit.Models;

namespace Utbildning.NUnit.UnitTests
{
    [TestFixture]
    public class Given_Website
    {
        protected WebSite SystemUnderTest { get; set; }

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            SystemUnderTest = new WebSite();
        }
        
        [SetUp]
        public void Setup()
        {
            SystemUnderTest.Articles = new[]
                           {
                               new Article {PublishedDate = new DateTime(2001, 1, 1)},
                               new Article {PublishedDate = new DateTime(2001, 1, 3)},
                               new Article {PublishedDate = new DateTime(2001, 1, 4)},
                               new Article {PublishedDate = new DateTime(2001, 1, 2)}
                           }; 
            SystemUnderTest.SortArticlesByDate();
        }

        [Test]
        public void should_sort_newest_article_first()
        {
           
            Assert.That(SystemUnderTest.Articles.First().PublishedDate, Is.EqualTo(new DateTime(2001, 1, 4)));
        }

        [Test]
        public void should_sort_oldest_article_last()
        {
            Assert.That(SystemUnderTest.Articles.Last().PublishedDate, Is.EqualTo(new DateTime(2001, 1, 1)));
        }
        //[Teardown]
    }
}
