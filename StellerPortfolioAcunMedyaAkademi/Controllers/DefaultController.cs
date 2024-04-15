using StellerPortfolioAcunMedyaAkademi.Models;
using System.Linq;
using System.Web.Mvc;

namespace StellerPortfolioAcunMedyaAkademi.Controllers
{
    public class DefaultController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultFeaturePartial()
        {
            var value = db.TblFeature.ToList();
            return PartialView(value);
        }
    }
}