using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryRepository _libraryRepository;
        public LibraryController()
        {
            this._libraryRepository = new LibraryRepository();
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
