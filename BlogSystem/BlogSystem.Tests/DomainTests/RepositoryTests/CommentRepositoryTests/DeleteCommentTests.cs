using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Domain.Concrete;
using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using Moq;
using NUnit.Framework;

namespace BlogSystem.Tests.DomainTests.RepositoryTests.CommentRepositoryTests
{
    [TestFixture]
    class DeleteCommentTests
    {
        [TestCase(2)]
        [TestCase(3)]
        public void TestDelete_PassValidId_ShouldDeleteComment(int id)
        {
            var mockedComment = new Mock<IComment>();
            mockedComment.SetupGet(x => x.CommentId).Returns(id);

            var mockedContext = new Mock<IApplicationDbContext>();
            mockedContext.SetupGet(context => context.Comments).Returns(It.IsAny<IDbSet<Comment>>());

            var repository = new CommentRepository(mockedContext.Object);

            repository.DeleteComment(id);

            mockedContext.VerifyGet(x => x.Comments, Times.Once);
        }
    }
}
