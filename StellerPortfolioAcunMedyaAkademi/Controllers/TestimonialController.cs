using System.Linq;
using System.Web.Mvc;
using StellerPortfolioAcunMedyaAkademi.Models;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class TestimonialController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial testimonial)
        {
            db.TblTestimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial tblTestimonial)
        {
            var value = db.TblTestimonial.FirstOrDefault(x => x.TestimonialID == tblTestimonial.TestimonialID);
            value.Title = tblTestimonial.Title;
            value.Description = tblTestimonial.Description; 
            value.NameSurname = tblTestimonial.NameSurname;
            value.TestimonialID = tblTestimonial.TestimonialID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}