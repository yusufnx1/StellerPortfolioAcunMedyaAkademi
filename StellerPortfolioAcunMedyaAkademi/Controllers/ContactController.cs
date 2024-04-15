using StellerPortfolioAcunMedyaAkademi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class ContactController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var value = db.TblContact.ToList();
            return View(value);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(TblContact tbl)
        {
            db.TblContact.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var result = db.TblContact.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContact tbl)
        {
            var value = db.TblContact.Find(tbl.ContactId);
            value.Location = tbl.Location;
            value.GoogleMap = tbl.GoogleMap;
            value.Phone = tbl.Phone;
            value.Email = tbl.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}