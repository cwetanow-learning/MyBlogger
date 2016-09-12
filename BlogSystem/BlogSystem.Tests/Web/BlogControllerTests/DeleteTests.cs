using BlogSystem.Domain.Contracts;
using BlogSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web.BlogControllerTests
{
    [TestFixture]
    class DeleteTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public void TestDelete_ShouldCallDeleteFromRepository(int id)
        {
            var mockedRepository = new Mock<IPostRepository>();

            var controller = new BlogController(mockedRepository.Object);

            controller.Delete(id);

            mockedRepository.Verify(x => x.DeletePost(id), Times.Once);
        }
    }
}
