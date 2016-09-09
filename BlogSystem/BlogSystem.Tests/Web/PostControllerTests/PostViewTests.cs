using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
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
    class PostViewTests
    {
        [TestCase(1)]
        [TestCase(3)]
        public void TestPostView_PassCorrectId_ShouldReturnCorrectPost(int id)
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.PostId).Returns(1);

            var mockedSecondPost = new Mock<IPost>();
            mockedSecondPost.SetupGet(p => p.PostId).Returns(3);

            var mockedThirdPost = new Mock<IPost>();
            mockedThirdPost.SetupGet(p => p.PostId).Returns(2);

            var mockedFourthPost = new Mock<IPost>();
            mockedFourthPost.SetupGet(p => p.PostId).Returns(6);

            var mockedFifthPost = new Mock<IPost>();
            mockedFifthPost.SetupGet(p => p.PostId).Returns(5);

            var mockedSixthPost = new Mock<IPost>();
            mockedSixthPost.SetupGet(p => p.PostId).Returns(11);

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

            var result = controller.PostView(id).Model as IPost;

            var expected = posts.FirstOrDefault(p => p.PostId == id);

            Assert.AreEqual(expected, result);
        }
    }
}
