using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers;
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
    public class TopPostsTests
    {
        [Test]
        public void TestTopPosts_ShouldCallRepositoryTopPosts()
        {
            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.IsDeleted).Returns(false);
            var comments = new List<Comment>();
            mockedPost.SetupGet(p => p.Comments).Returns(comments);

            var posts = new List<IPost> { mockedPost.Object }.OrderBy(x => x.IsDeleted);

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.Setup(x => x.GetTopPosts()).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            controller.TopPosts(GlobalConstants.HomePageTopPostsCount);

            mockedRepository.Verify(x => x.GetTopPosts(), Times.Once);

        }
    }
}
