using StellerPortfolioAcunMedyaAkademi.Models;
using System.Linq;
using System.Web.Mvc;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class ServiceController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var value = db.TblService.ToList();
            return View(value);
        }
        public ActionResult DeleteService(int id)
        {
            var value = db.TblService.Find(id);
            db.TblService.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(TblService tbl)
        {
            tbl.ServiceStatus = true;
            db.TblService.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService tbl)
        {
            var value = db.TblService.Find(tbl.ServiceID);
            value.ServiceName = tbl.ServiceName;
            value.ServiceStatus = true;
            value.IconUrl = tbl.IconUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}