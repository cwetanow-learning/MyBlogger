using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using BlogSystem.Web.Controllers;
using BlogSystem.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web.CommentControllerTests
{
    [TestFixture]
    public class TestCommentPost
    {
        [Test]
        public void TestCommentPost_PassValidData_ShouldCallRepositoryWriteComment()
        {
            var mockedModel = new Mock<CommentViewModel>();

            var mockedRepository = new Mock<ICommentRepository>();

            var controller = new CommentController(mockedRepository.Object);

            controller.CommentPost(mockedModel.Object);

            mockedRepository.Verify(x => x.WriteComment(It.IsAny<Comment>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }
    }
}
