using Microsoft.AspNetCore.Mvc;
using System;
using Data;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpPost]
        [Route("{borrowbook}")]
        public IActionResult BorrowBook([FromBody] Book book)
        {
            string message;
            try
            {
               var returnDate = this._libraryRepository.BorrowBook(book).ToString("dd-MMM-yyyy");
                message = $"{book.Title} borrowed until the {returnDate}";
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }

            return this.Ok(message);
        }
    }
}
