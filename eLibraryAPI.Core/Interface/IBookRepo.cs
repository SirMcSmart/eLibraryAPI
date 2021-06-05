using eLibraryAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryAPI.Core.Interface
{
    public interface IBookRepo
    {
        List<Book> GetAllBooks();
        Book GetBookById(int Id);
    }
}
