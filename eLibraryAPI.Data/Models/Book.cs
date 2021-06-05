using eLibraryAPI.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryAPI.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookEdition { get; set; }
        public string ISBN { get; set; }
        public string BookAuthor { get; set; }
        public Category Categories { get; set; }
       
        public DateTime PublishedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        


    }
}
