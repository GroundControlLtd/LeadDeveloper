using System;
using Api.Controllers;
using Data;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Xunit;

namespace Interview.Api.Tests
{
    public class LibraryControllerShould
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("Unknown", "Unknown")]
        [InlineData("Brave New World", "Unknown")]
        [InlineData("Unknown", "Aldous Huxley")]
        public void ReturnNotFoundWhenBorrowingBookGivenUnknownBookTitleOrBookAuthor(string bookTitle, string bookAuthor)
        {
            //Arrange
            const string expectedValue = "Book not found!";
            var libraryRepository = new LibraryRepository();
            var controller = new LibraryController(libraryRepository);
            var book = new Book {Title=bookTitle, Author = bookAuthor};
            //Act
            var response = controller.BorrowBook(book);
            var actualValue = ((ObjectResult)response).Value;
            //Assert
            Assert.NotNull(actualValue);
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("Brave New World", "Aldous Huxley")]
        public void ReturnExpectedValueWhenBorrowingBookGivenKnownBookAndBookAuthor(string bookTitle, string bookAuthor)
        {
            //Arrange
            var returnDate = DateTime.Now.AddDays(30).ToString("dd-MMM-yyyy");
            var expectedValue = $"{bookTitle} borrowed until the {returnDate}";
            var libraryRepository = new LibraryRepository();
            var controller = new LibraryController(libraryRepository);
            var book = new Book { Title = bookTitle, Author = bookAuthor };
            //Act
            var response = controller.BorrowBook(book);
            var actualValue = ((ObjectResult)response).Value;
            //Assert
            Assert.NotNull(actualValue);
            Assert.Equal(expectedValue, actualValue);
        }

    }
}
