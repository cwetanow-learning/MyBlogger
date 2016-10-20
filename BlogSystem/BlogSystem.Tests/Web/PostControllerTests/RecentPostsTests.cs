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
        public void TestLatestPosts_ShouldCallRepositoryLatestPosts()
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
            }.OrderBy(x => x.PostId);

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.Setup(x => x.GetLatestPosts()).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            controller.LatestPosts(GlobalConstants.HomePageTopPostsCount);

            mockedRepository.Verify(x => x.GetLatestPosts(), Times.Once);
        }
    }
}
