using BlogSystem.Web.Controllers;
using BlogSystem.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web.PostControllerTests
{
    [TestFixture]
    class ListTests
    {
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        [TestCase(true, false)]
        public void TestList_ShouldReturnModelWithCorrectProperties(bool date, bool rating)
        {
            var controller = new PostController(null);

            var result = controller.List(date, rating).Model as ListPostViewModel;

            Assert.AreEqual(date, result.ByDate);
            Assert.AreEqual(rating, result.ByRating);
        }
    }
}
