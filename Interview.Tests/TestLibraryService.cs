using Moq;
using System;
using Xunit;
using Interview.Interfaces;
using Shared;
using FluentAssertions;
using System.Threading.Tasks;

namespace Interview.Services.Tests
{
    public class TestLibraryService
    {
        [Fact]
        public void TestBorrowBook_successfully()
        {
            //Arrange
            var mockLibraryServiceConfiguration = new Mock<ILibraryServiceConfiguration>();
            mockLibraryServiceConfiguration.SetupGet(x => x.BaseUrl).Returns("https://localhost:44321");
            mockLibraryServiceConfiguration.SetupGet(x => x.ServiceEndpoint).Returns("/api/library/borrowbook");
            var libraryService = new LibraryService(mockLibraryServiceConfiguration.Object);
            var book = new Book { Author = "Aldous Huxley", Title = "Brave New World" };

            //Act
            var actualResult = libraryService.BorrowBook(book).Result;

            //Assert
            Assert.Contains(book.Title, actualResult);
        }

        [Fact]
        public void TestBorrowBook_failure_book_not_found()
        {
            //Arrange
            var mockLibraryServiceConfiguration = new Mock<ILibraryServiceConfiguration>();
            mockLibraryServiceConfiguration.SetupGet(x => x.BaseUrl).Returns("https://localhost:44321");
            mockLibraryServiceConfiguration.SetupGet(x => x.ServiceEndpoint).Returns("/api/library/borrowbook");
            var libraryService = new LibraryService(mockLibraryServiceConfiguration.Object);
            var book = new Book { Author = "test", Title = "Abc" };

            //Act
            var actualResult = libraryService.BorrowBook(book).Result;

            //Assert
            Assert.Equal("Book not found!", actualResult);
        }

        [Fact]
        public void TestBorrowBook_failure_should_throw_exception()
        {
            //Arrange
            var mockLibraryServiceConfiguration = new Mock<ILibraryServiceConfiguration>();
            mockLibraryServiceConfiguration.SetupGet(x => x.BaseUrl).Returns("https://localhost:44321");
            mockLibraryServiceConfiguration.SetupGet(x => x.ServiceEndpoint).Returns("/api/library/borrowbook");
            var libraryService = new LibraryService(mockLibraryServiceConfiguration.Object);

            //Act
            //Assert
            Func<Task> f = async () => { await libraryService.BorrowBook(null); };
            f.Should().ThrowAsync<Exception>();
        }
    }
}
