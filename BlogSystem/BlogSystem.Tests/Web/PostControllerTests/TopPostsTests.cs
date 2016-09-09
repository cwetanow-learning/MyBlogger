using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web
{
    [TestFixture]
    public class TopPostsTests
    {
        [Test]
        public void TestTopPosts_PassFewerPosts_ShouldReturnAll()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.IsDeleted).Returns(false);

            var posts = new List<IPost> { mockedPost.Object };

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.SetupGet(x => x.Posts).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            var result = controller.TopPosts().Model;

            Assert.AreEqual(posts, result);
        }

        [Test]
        public void TestTopPosts_PassFewerWithDatesPosts_ShouldFilterCorrectlyAndReturnAll()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.IsDeleted).Returns(false);
            mockedPost.SetupGet(p => p.Date).Returns(DateTime.Now);

            var mockedSecondPost = new Mock<IPost>();
            mockedSecondPost.SetupGet(p => p.IsDeleted).Returns(false);

            var posts = new List<IPost> { mockedSecondPost.Object, mockedPost.Object };

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.SetupGet(x => x.Posts).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            var result = controller.TopPosts().Model as IEnumerable<IPost>;

            Assert.AreEqual(mockedPost.Object, result.ElementAt(0));
            Assert.AreEqual(mockedSecondPost.Object, result.ElementAt(1));
        }

        [Test]
        public void TestTopPosts_PassMorePostsWithOneDeleted_ShouldReturnCorrectPosts()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedSecondPost = new Mock<IPost>();
            mockedSecondPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedThirdPost = new Mock<IPost>();
            mockedThirdPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedFourthPost = new Mock<IPost>();
            mockedFourthPost.SetupGet(p => p.IsDeleted).Returns(true);

            var mockedFifthPost = new Mock<IPost>();
            mockedFifthPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedSixthPost = new Mock<IPost>();
            mockedSixthPost.SetupGet(p => p.IsDeleted).Returns(false);

            var posts = new List<IPost> {
                mockedSecondPost.Object,
                mockedPost.Object,
                mockedThirdPost.Object,
                mockedFourthPost.Object,
                mockedFifthPost.Object,
                mockedSixthPost.Object
            };

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.SetupGet(x => x.Posts).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            var result = controller.TopPosts().Model as IEnumerable<IPost>;

            var expected = posts.Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestTopPosts_PassMorePosts_ShouldReturn5()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedSecondPost = new Mock<IPost>();
            mockedSecondPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedThirdPost = new Mock<IPost>();
            mockedThirdPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedFourthPost = new Mock<IPost>();
            mockedFourthPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedFifthPost = new Mock<IPost>();
            mockedFifthPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedSixthPost = new Mock<IPost>();
            mockedSixthPost.SetupGet(p => p.IsDeleted).Returns(false);

            var posts = new List<IPost> {
                mockedSecondPost.Object,
                mockedPost.Object,
                mockedThirdPost.Object,
                mockedFourthPost.Object,
                mockedFifthPost.Object,
                mockedSixthPost.Object
            };

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.SetupGet(x => x.Posts).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            var result = controller.TopPosts().Model as IEnumerable<IPost>;

            var expected = posts.Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            Assert.AreEqual(expected, result);
        }
    }
}
