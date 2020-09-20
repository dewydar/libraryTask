using libraryTask.BL;
using libraryTask.Models;
using libraryTask.Models.LibraryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace libraryTask.DBManagers
{
    public class Customermanager : Repository<Customers, ApplicationDbContext>
    {
        public Customermanager(ApplicationDbContext _context) : base(_context)
        {
        }


    }

}