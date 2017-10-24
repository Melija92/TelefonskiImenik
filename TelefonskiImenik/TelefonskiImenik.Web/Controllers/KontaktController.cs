using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonskiImenik.DataLayer;
using TelefonskiImenik.Model;
using TelefonskiImenik.Web.ViewModels;

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
        public ActionResult Detalji(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Kontakt kontakt = _appContext.Kontakti.Find(id);
            if (kontakt == null)
                return HttpNotFound();

            KontaktViewModel kontaktViewModel = KontktUViewModel.KreiranjeViewModelaIzModela(kontakt, _appContext);

            return View(kontaktViewModel);
        }


        public ActionResult Dodaj()
        {
            KontaktViewModel kontaktViewModel = new KontaktViewModel()
            {
                Grad = _appContext.Gradovi.ToList(),
                Status = Status.Dodano
            };

            return View(kontaktViewModel);
        }

        public ActionResult Uredi(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Kontakt kontakt = _appContext.Kontakti.Find(id);
            if (kontakt == null)
                return HttpNotFound();

            KontaktViewModel kontaktViewModel = KontktUViewModel.KreiranjeViewModelaIzModela(kontakt, _appContext);


            return View(kontaktViewModel);
        }


        public ActionResult Izbrisi(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Kontakt kontakt = _appContext.Kontakti.Find(id);
            if (kontakt == null)
                return HttpNotFound();

            KontaktViewModel kontaktViewModel = KontktUViewModel.KreiranjeViewModelaIzModela(kontakt, _appContext);
            kontaktViewModel.Status = Status.Izbrisano;
            return View(kontaktViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _appContext.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult Spremi(KontaktViewModel kontaktViewModel, HttpPostedFileBase slikaKontakta)
        {
            Kontakt kontakt = KontktUViewModel.KreiranjeKontaktaIzViewModela(kontaktViewModel);



            _appContext.Kontakti.Attach(kontakt);

            if (kontakt.Status == Status.Izbrisano)
            {
                foreach (BrojViewModel brojViewModel in kontaktViewModel.Brojevi)
                {
                    Broj broj = _appContext.Brojevi.Find(brojViewModel.BrojId);
                    if (broj != null)
                        broj.Status = Status.Izbrisano;
                }
            }
            else
            {
                foreach (int brojId in kontaktViewModel.BrojeviZaBrisanje)
                {
                    Broj broj = _appContext.Brojevi.Find(brojId);
                    if (broj != null)
                        broj.Status = Status.Izbrisano;
                }
            }

            _appContext.ApplyStateChanges();
            _appContext.SaveChanges();
            
            if (kontakt.Status == Status.Izbrisano)
                return Json(new { newLocation = "/Kontakt/Index" });
            
            kontaktViewModel = KontktUViewModel.KreiranjeViewModelaIzModela(kontakt, _appContext);

            return Json(new { kontaktViewModel });
        }
    }
}