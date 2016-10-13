using BlogSystem.Domain.Models;
using BlogSystem.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web.BlogControllerTests
{
    [TestFixture]
    class CreateTests
    {
        [Test]
        public void TestCreate_ShouldReturnNewPostAndCorrectView()
        {
            var controller = new BlogController(null, null);

            var result = controller.Create();

            var expectedPost = result.Model as Post;
            var expectedViewName = result.ViewName;

            Assert.IsNotNull(expectedPost);
            Assert.IsInstanceOf<Post>(expectedPost);
            Assert.AreEqual(expectedViewName, "Edit");
        }
    }
}
