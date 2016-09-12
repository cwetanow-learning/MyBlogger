using BlogSystem.Domain.Contracts;
using BlogSystem.Web.Controllers;
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
    class DeleteTests
    {
        [TestCase(1,2)]
        [TestCase(2,11)]
        public void TestDelete_ShouldCallDeleteFromRepository(int id, int commentId)
        {
            var mockedRepository = new Mock<ICommentRepository>();

            var controller = new CommentController(mockedRepository.Object);

            controller.Delete(commentId, id);

            mockedRepository.Verify(x => x.DeleteComment(commentId), Times.Once);
        }
    }
}
