using AutoMapper;
using eLibraryAPI.Data.DTOs;
using eLibraryAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryAPI.Data.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            //Source ==> Target
            CreateMap<Book, BookReadDTO>();
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<Book, BookUpdateDTO>();
        }
    }
}
