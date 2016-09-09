using BlogSystem.Domain.Contracts.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web
{
    [TestFixture]
    public class PostControllerTests
    {
        [Test]
        public void TestTopPosts_PassFewerPosts_ShouldReturnAll()
        {
            var mockedPost = new Mock<IPost>();
            //mockedPost.SetupGet(p=>p)
        }
    }
}
