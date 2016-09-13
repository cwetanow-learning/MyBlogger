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

namespace BlogSystem.Tests.Web.SearchControllerTests
{
    [TestFixture]
    class InitialiseTests
    {
        [Test]
        public void ConstructorTests_ShouldInitialiseCorrectInstanceOfBase()
        {
            var mockedPostRepository = new Mock<IPostRepository>();

            var controller = new SearchController(mockedPostRepository.Object);

            Assert.IsInstanceOf<BaseController>(controller);
        }

        [Test]
        public void ConstructorTests_ShouldInitialiseCorrectly()
        {
            var mockedPostRepository = new Mock<IPostRepository>();

            var controller = new SearchController(mockedPostRepository.Object);

            Assert.IsNotNull(controller);
        }
    }
}
