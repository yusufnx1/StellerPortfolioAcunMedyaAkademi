using StellerPortfolioAcunMedyaAkademi.Models;
using System.Linq;
using System.Web.Mvc;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class AboutController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(TblAbout about)
        {
            db.TblAbout.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout about)
        {
            var value = db.TblAbout.FirstOrDefault(x=>x.AboutID == about.AboutID);
            value.NameSurname = about.NameSurname;
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            value.AboutID = about.AboutID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}