using System.Linq;
using System.Web.Mvc;
using TelefonskiImenik.DataLayer;

namespace TelefonskiImenik.Web.Controllers
{
    public class KontaktController : Controller
    {
        private ApplicationContext _appContext;

        public KontaktController()
        {
            _appContext = new ApplicationContext();
        }
        
        public ActionResult Index()
        {
            return View(_appContext.Kontakti.ToList());
        }
    }
}