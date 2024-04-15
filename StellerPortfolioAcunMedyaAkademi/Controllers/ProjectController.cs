using System.Linq;
using System.Web.Mvc;
using StellerPortfolioAcunMedyaAkademi.Models;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class ProjectController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var value = db.TblProject.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject tblProject)
        {
            db.TblProject.Add(tblProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProject.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject tblProject)
        {
            var value = db.TblProject.FirstOrDefault(x=>x.ProjectId == tblProject.ProjectId);
            value.ProjectName = tblProject.ProjectName;
            value.GithubUrl = tblProject.GithubUrl;
            value.ImageUrl = tblProject.ImageUrl;
            value.Description = tblProject.Description;
            value.ProjectId = tblProject.ProjectId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}