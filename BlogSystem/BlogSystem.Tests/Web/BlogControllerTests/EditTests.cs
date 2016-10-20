using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using BlogSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogSystem.Tests.Web.BlogControllerTests
{
    [TestFixture]
    class EditTests
    {
        [TestCase(1)]
        [TestCase(5)]
        public void TestEdit_ShouldCallRepositoryGetById(int id)
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
            mockedRepository.Setup(x => x.GetPostById(id)).Returns(posts.FirstOrDefault(x => x.PostId == id));

            var controller = new BlogController(mockedRepository.Object, null);

            controller.Edit(id);

            mockedRepository.Verify(x => x.GetPostById(id), Times.Once);
        }

        [Test]
        public void TestEdit_PassInvalidModelState_ShouldReturnSameView()
        {
            var mockedPost = new Mock<Post>();

            var controller = new BlogController(null, null);

            controller.ModelState.AddModelError("Invalid", "Invalid");

            var result = controller.Edit(mockedPost.Object);

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
