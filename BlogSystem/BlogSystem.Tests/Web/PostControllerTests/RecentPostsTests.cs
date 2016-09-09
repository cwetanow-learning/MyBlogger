using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web.PostControllerTests
{
    [TestFixture]
    public class RecentPostsTests
    {
        [Test]
        public void TestLatestPosts_PassFewerPosts_ShouldReturnAll()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.IsDeleted).Returns(false);

            var posts = new List<IPost> { mockedPost.Object };

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.SetupGet(x => x.Posts).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            var result = controller.LatestPosts().Model;

            Assert.AreEqual(posts, result);
        }

        [Test]
        public void TestLatestPosts_PassMorePostsWithOneDeleted_ShouldReturnCorrectPosts()
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

            var result = controller.LatestPosts().Model as IEnumerable<IPost>;

            var expected = posts.Where(p => !p.IsDeleted)
                 .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestLatestPosts_PassMorePosts_ShouldReturnCorrectly()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.Date).Returns(DateTime.Now);

            var mockedSecondPost = new Mock<IPost>();
            mockedSecondPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedThirdPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.Date).Returns(DateTime.Now);

            var mockedFourthPost = new Mock<IPost>();
            mockedFourthPost.SetupGet(p => p.IsDeleted).Returns(false);

            var mockedFifthPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.Date).Returns(DateTime.Now);

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

            var result = controller.LatestPosts().Model as IEnumerable<IPost>;

            var expected = posts.Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            Assert.AreEqual(expected, result);
        }
    }
}
