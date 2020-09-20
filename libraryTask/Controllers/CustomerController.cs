using System.Web.Mvc;
using libraryTask.BL;
using libraryTask.Models.LibraryDB;
namespace libraryTask.Controllers
{
    public class CustomerController : Controller
    {
        UnitOfWork unit = UnitOfWork.GetInstance();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult RemotCreate([Bind(Exclude ="ID")]Customers customer)
        {
           var result= unit.Customermanager.Add(customer);
            return Json(new { data = result, msg = result == null ? false : true }, JsonRequestBehavior.AllowGet);
        }
    }
}