using BlogSystem.Domain.Concrete;
using BlogSystem.Domain.Contracts;
using Moq;
using NUnit.Framework;

namespace BlogSystem.Tests.DomainTests.RepositoryTests
{
    [TestFixture]
    class ConstructorTests
    {
        [Test]
        public void TestPostRepositoryConstructor_ShouldInitialiseCorrectly()
        {
            var mockedDbContext = new Mock<IApplicationDbContext>();

            var repository = new PostRepository(mockedDbContext.Object);

            Assert.IsNotNull(repository);
            Assert.IsInstanceOf<IPostRepository>(repository);
        }

        [Test]
        public void TestCommentRepositoryConstructor_ShouldInitialiseCorrectly()
        {
            var mockedDbContext = new Mock<IApplicationDbContext>();

            var repository = new CommentRepository(mockedDbContext.Object);

            Assert.IsNotNull(repository);
            Assert.IsInstanceOf<ICommentRepository>(repository);
        }
    }
}
