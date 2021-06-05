using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibraryAPI.Core.Interface;
using eLibraryAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace eLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _br;

        public BookController(IBookRepo br)
        {
            _br = br;
        }

        //GET /api/books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            var bookItems = _br.GetAllBooks();
            return Ok(bookItems);
        }

        //GET /api/books/{Id}
        [HttpGet ("{Id}", Name="GetBookById")]
        public ActionResult<Book> GetBookById(int Id,string bookName)
        {
            var bookItem = _br.GetBookById(Id);

            if (bookItem != null)
            {
                return Ok(bookItem);

            }
            return NotFound();
        }


}
}