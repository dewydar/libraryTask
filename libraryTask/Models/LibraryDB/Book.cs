using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace libraryTask.Models.LibraryDB
{
    [Table("Book")]
    public class Book
    {
        public Book()
        {
            BookTransactions = new HashSet<BookTransaction>();
        }
        public int ID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Must Be >0")]
        public int NumberOfCopies { get; set; }
        public IEnumerable<BookTransaction> BookTransactions { get; set; }
    }
}