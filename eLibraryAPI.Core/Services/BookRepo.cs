using eLibraryAPI.Core.Interface;
using eLibraryAPI.Data.Context;
using eLibraryAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLibraryAPI.Core.Services
{
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext _adc;

        public BookRepo(ApplicationDbContext adc)
        {
            _adc = adc;
        }


        public List<Book> GetAllBooks()
        {
            var bookList = _adc.Books.ToList();

            return bookList;
        }

        public Book GetBookById(int Id)
        {
            return _adc.Books.FirstOrDefault(p => p.Id == Id);
        }


        public void CraeteBook(Book bk)
        {
            try
            {
                if(bk == null)
                {
                    throw new ArgumentNullException(nameof(bk));
                }
                else
                {
                    _adc.Books.Add(bk);

                  
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool SaveChanges()
        {
            var bc = _adc.SaveChanges();
            return (bc >= 0);
        }

        public void UpdatePutBook(Book bk)
        {
            // Nothing
        }

        public void DeleteBook(Book bk)
        {
            if(bk == null)
            {
                throw new ArgumentNullException(nameof(bk));
            }
            _adc.Books.Remove(bk);
        }
    }
}
