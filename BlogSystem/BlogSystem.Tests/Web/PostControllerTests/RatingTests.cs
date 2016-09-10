using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Web.PostControllerTests
{
    [TestFixture]
    public class RatingTests
    {
        [TestCase(1)]
        [TestCase(-1)]
        public void TestRating_PassValidValues_ShouldReturnCorrectPost(int ratingChange)
        {
            var postId = 1;
            var rating = 5;

            var mockedPost = new Mock<IPost>();
            mockedPost.SetupGet(p => p.Rating).Returns(rating);
            mockedPost.SetupGet(p => p.PostId).Returns(postId);

            var posts = new List<IPost> {
                mockedPost.Object
            };

            var mockedRepository = new Mock<IPostRepository>();
            mockedRepository.SetupGet(x => x.Posts).Returns(posts);

            var controller = new PostController(mockedRepository.Object);

            var result = (int)controller.Rating(postId, ratingChange).Model;

            var expected = mockedPost.Object.Rating + ratingChange;

            mockedRepository.Verify(x => x.ChangeRating(postId, ratingChange),Times.Once);
        }
    }
}
