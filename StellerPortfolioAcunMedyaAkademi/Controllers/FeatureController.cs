using StellerPortfolioAcunMedyaAkademi.Models;
using System.Linq;
using System.Web.Mvc;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class FeatureController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var result = db.TblFeature.ToList();
            return View(result);
        }
        public ActionResult DeleteFeature(int id)
        {
            var result = db.TblFeature.Find(id);
            db.TblFeature.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFeature(TblFeature tbl)
        {
            db.TblFeature.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var result = db.TblFeature.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature tbl)
        {
            var value = db.TblFeature.Find(tbl.FeatureID);
            value.NameSurname = tbl.NameSurname;
            value.CvDownloadUrl = tbl.CvDownloadUrl;
            value.Title = tbl.Title;
            value.Job = tbl.Job;
            value.ImageUrl = tbl.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}