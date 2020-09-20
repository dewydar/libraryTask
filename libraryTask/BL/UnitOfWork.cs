using libraryTask.DBManagers;
using libraryTask.Models;
using libraryTask.Models.LibraryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace libraryTask.BL
{
    public class UnitOfWork : IDisposable
    {
        static UnitOfWork unit;
        private bool _disposed;

        private ApplicationDbContext context;
        private UnitOfWork()
        {
            context = new ApplicationDbContext();
        }
        public static UnitOfWork GetInstance()
        {

            if (unit == null)
            {
                unit = new UnitOfWork();
            }
            return unit;
        }
        public BookManager bookManager
        {
            get
            {
                return new BookManager(context);
            }
        } public BorrowBookManger BorrowBookManger
        {
            get
            {
                return new BorrowBookManger(context);
            }
        }
        public Customermanager Customermanager
        {
            get
            {
                return new Customermanager(context);
            }
        }

        public void Dispose()
        {
            if(!_disposed)

            if (context != null)
                unit.Dispose();
            _disposed = true;


        }
    }
}