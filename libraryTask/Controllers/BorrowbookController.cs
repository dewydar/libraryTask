using libraryTask.BL;
using libraryTask.Models.LibraryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libraryTask.Controllers
{
    public class BorrowbookController : Controller
    {
        UnitOfWork unit = UnitOfWork.GetInstance();
        // GET: Borrowbook
        public ActionResult create()
        {
            ViewBag.Customers = new SelectList(unit.Customermanager.GetAll().ToList(), "ID", "CustomerName");
            BookTransaction bookTransaction = new BookTransaction();
            bookTransaction.EndDate=DateTime.Now.Date;
            return View(bookTransaction);
        }
        public JsonResult save(BookTransaction bookTransaction)
        {
            if (unit.BorrowBookManger.GetAll().Where(a => a.CustomerID == bookTransaction.CustomerID && a.EndDate == null).FirstOrDefault() == null)
            {
                var BorrowBook = unit.BorrowBookManger.GetAll().Where(a => a.BookID == bookTransaction.BookID && a.EndDate == null).Count();
                var NumberOfCopies = unit.bookManager.GetById(bookTransaction.BookID).NumberOfCopies;
                if (BorrowBook >= NumberOfCopies)
                {
                    return Json(new { msg = "No Copy Of This Book Avilble Right Now", status = false }, JsonRequestBehavior.AllowGet);
                }
                var result = unit.BorrowBookManger.Add(bookTransaction);
                return result == null ? Json(new { msg = "Some thing Wrong Happend Plesae try Again", status = false }, JsonRequestBehavior.AllowGet) : Json(new { msg = "Book Borrowed Successfuly", status = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "This Customer Have Another Borrowed Book ", status = false }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Retrieve(BookTransaction bookTransaction)
        {
            var Book = unit.BorrowBookManger.GetAll().Where(a => a.CustomerID == bookTransaction.CustomerID && a.EndDate == null).FirstOrDefault();
            
            if (Book != null)
            {
                Book.EndDate = bookTransaction.EndDate;
                if (  unit.BorrowBookManger.Update(Book))
                {
                    return Json(new { msg = "Book Retrieve Successfully", status = true }, JsonRequestBehavior.AllowGet);
                }
              else
                {
                    return Json(new { msg = "There are an error Try Again", status = false }, JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json(new { msg = "This User Dont Have Borrowed Book", status = false }, JsonRequestBehavior.AllowGet);

        }



    }
}