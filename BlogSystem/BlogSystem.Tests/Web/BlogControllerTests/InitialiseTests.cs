using BlogSystem.Domain.Contracts;
using BlogSystem.Web.Controllers;
using BlogSystem.Web.Controllers.Abstract;
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
    class InitialiseTests
    {
        [Test]
        public void ConstructorTests_ShouldInitialiseCorrectInstanceOfBase()
        {
            var mockedRepository = new Mock<IPostRepository>();

            var controller = new BlogController(mockedRepository.Object, null);

            Assert.IsInstanceOf<BaseController>(controller);
        }

        [Test]
        public void ConstructorTests_ShouldInitialiseCorrectly()
        {
            var mockedRepository = new Mock<IPostRepository>();

            var controller = new BlogController(mockedRepository.Object, null);

            Assert.IsNotNull(controller);
        }
    }
}
