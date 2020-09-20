using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace libraryTask.Models.LibraryDB
{
    public class Customers
    {
        public Customers()
        {
            BookTransactions = new HashSet<BookTransaction>();
        }
        public int ID { get; set; }
        public string CustomerName { get; set; }
        [MaxLength(11,ErrorMessage ="Invalid Mobile Number")]
        //[RegularExpression("^01[0-2][0-9]{8}$",ErrorMessage ="Invalid Number")]
        
        public string  Mobile { get; set; }
        public IEnumerable<BookTransaction> BookTransactions { get; set; }


    }
}