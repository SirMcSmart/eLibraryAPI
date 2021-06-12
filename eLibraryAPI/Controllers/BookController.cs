using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eLibraryAPI.Core.Interface;
using eLibraryAPI.Data.DTOs;
using eLibraryAPI.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace eLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _br;
        private readonly IMapper _mapper;

        public BookController(IBookRepo br, IMapper mapper)
        {
            _br = br;
            _mapper = mapper;
        }

        //GET /api/books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            var bookItems = _br.GetAllBooks();
            return Ok(_mapper.Map<IEnumerable<BookReadDTO>>(bookItems));
           // return Ok(bookItems);
        }

        //GET /api/books/{Id}
        [HttpGet ("{Id}", Name="GetBookById")]
        public ActionResult<Book> GetBookById(int Id)
        {
            var bookItem = _br.GetBookById(Id);

            if (bookItem != null)
            {
                return Ok(_mapper.Map<BookReadDTO>(bookItem));
                //return Ok(bookItem);
            }
            return NotFound();
        }

        //POST /api/books
        [HttpPost]
        public ActionResult<BookReadDTO>CreateBook(BookCreateDTO bCreateBook)
        {
            try
            {
                var bookModel = _mapper.Map<Book>(bCreateBook);
                _br.CraeteBook(bookModel);
                _br.SaveChanges();

                var bReadDTO = _mapper.Map<BookReadDTO>(bookModel);

                return CreatedAtRoute(nameof(GetBookById), new { Id = bReadDTO.Id }, bReadDTO);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //PUT /api/books/{Id}
        [HttpPut]
        public ActionResult UpdatePutBook(int Id, BookUpdateDTO bUpdateDTO)
        {
            var bookModelFromRepo = _br.GetBookById(Id);

            if(bookModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(bUpdateDTO, bookModelFromRepo);

                _br.UpdatePutBook(bookModelFromRepo);
                _br.SaveChanges();

                return NoContent();
            }

        }

        // PATCH /api/books/{Id}
        [HttpPatch ("{Id}")]
        public ActionResult UpdatePatchBook(int Id, JsonPatchDocument<BookUpdateDTO> patchDoc)
        {
            try
            {
                var bookModelFromRepo = _br.GetBookById(Id);

                if (bookModelFromRepo == null)
                {
                    return NotFound();
                }
                else
                {
                   var bookToPatch =  _mapper.Map<BookUpdateDTO>(bookModelFromRepo);
                    patchDoc.ApplyTo(bookToPatch, ModelState);
                    if (!TryValidateModel(bookToPatch))
                    {
                        return ValidationProblem(ModelState);
                    }

                    _mapper.Map(bookToPatch, bookModelFromRepo);

                    _br.UpdatePutBook(bookModelFromRepo);
                    _br.SaveChanges();

                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //DELETE /api/books/{Id}
        [HttpDelete("{Id}")]
        public ActionResult DeleteBook(int Id, BookUpdateDTO dUpdateDTO)
        {
            var bookModelFromRepo = _br.GetBookById(Id);
            if(bookModelFromRepo == null)
            {
                return NotFound();
            }

            _br.DeleteBook(bookModelFromRepo);
            _br.SaveChanges();

            return NoContent();
        }

    }
}