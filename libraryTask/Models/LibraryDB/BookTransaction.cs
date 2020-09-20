using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace libraryTask.Models.LibraryDB
{
    public class BookTransaction
    {
        public int ID { get; set; }
        [Required]
        [ForeignKey("book")]
        public int BookID { get; set; }
        [Required]
        [ForeignKey("customer")]

        public int CustomerID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Customers customer { get; set; }
        public Book book { get; set; }
    }
}