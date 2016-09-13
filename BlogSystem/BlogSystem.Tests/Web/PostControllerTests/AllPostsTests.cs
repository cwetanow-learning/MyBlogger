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
    class AllPostsTests
    {
        [Test]
        public void TestAllPosts_PassCorrectPost_ShouldReturnCorrectPostsAndView()
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

            var result = controller.AllPosts(posts, posts.Count);
            var expectedPosts = result.Model as IEnumerable<IPost>;
            var expectedView = result.ViewName;

            Assert.AreEqual(posts, expectedPosts);
            Assert.AreEqual(expectedView, "_TopPostsPartial");
        }
    }
}
