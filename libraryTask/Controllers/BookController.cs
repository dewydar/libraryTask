using libraryTask.BL;
using libraryTask.Models.LibraryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libraryTask.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        UnitOfWork unit = UnitOfWork.GetInstance();

        public ActionResult Index()
        {
            ViewBag.Customers = new SelectList(unit.Customermanager.GetAll().ToList().Select(x=> new { ID=x.ID,Name=x.CustomerName+"-"+x.Mobile}), "ID", "Name");
            return View();
        }
        public JsonResult Getall()
        {
            return Json(new { data = unit.bookManager.GetAll() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get(int id)
        {
            return Json(new { data = unit.bookManager.GetById(id) }, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult Save(Book book)
        {
            try
            {
                if (book.ID == 0)
                {
                    var result = unit.bookManager.Add(book);

                    return Json(new { msg = result == null ? false : true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = unit.bookManager.Update(book);

                    return Json(new { msg = result }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(new { msg = false }, JsonRequestBehavior.AllowGet);

            }
           
        }
        [HttpGet]
        public JsonResult GetBooks(string sText)
        {
            var result = unit.bookManager.GetAll().ToList().Where(x => x.AuthorName.Contains(sText) || x.BookName.Contains(sText)).Select(x=>new { ID=x.ID,Name=x.BookName}).ToList();
            return new JsonResult { Data = result,JsonRequestBehavior=JsonRequestBehavior.AllowGet };

        }

    }
}