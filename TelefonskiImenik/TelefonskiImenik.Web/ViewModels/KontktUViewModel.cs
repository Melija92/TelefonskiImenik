using System.Linq;
using TelefonskiImenik.DataLayer;
using TelefonskiImenik.Model;

namespace TelefonskiImenik.Web.ViewModels
{
    public static class KontktUViewModel
    {
        public static KontaktViewModel KreiranjeViewModelaIzModela(Kontakt kontakt, ApplicationContext _appContext)
        {
            KontaktViewModel kontaktViewModel = new KontaktViewModel()
            {
                KontaktId = kontakt.KontaktId,
                Ime = kontakt.Ime,
                Prezime = kontakt.Prezime,
                Slika = kontakt.Slika,
                Grad = _appContext.Gradovi.ToList(),
                GradId = kontakt.GradId,
                NazivGrada = kontakt.Grad.NazivGrada,
                Opis = kontakt.Opis,
                Status = Status.Nepromijenjeno
            };

            foreach (Broj broj in kontakt.Brojevi)
            {
                BrojViewModel brojViewModel = new BrojViewModel()
                {
                    BrojId = broj.BrojId,
                    SadrzajBroja = broj.SadrzajBroja,
                    Opis = broj.TipBroja,
                    TipBroja = broj.TipBroja,
                    Status = Status.Nepromijenjeno,
                    KontaktId = broj.KontaktId
                };
                kontaktViewModel.Brojevi.Add(brojViewModel);
            };

            return kontaktViewModel;
        }

        public static Kontakt KreiranjeKontaktaIzViewModela(KontaktViewModel kontaktViewModel)
        {
            Kontakt kontakt = new Kontakt()
            {
                KontaktId = kontaktViewModel.KontaktId,
                Ime = kontaktViewModel.Ime,
                Prezime = kontaktViewModel.Prezime,
                Slika = kontaktViewModel.Slika,
                Opis = kontaktViewModel.Opis,
                GradId = kontaktViewModel.GradId,
                Status = kontaktViewModel.Status
            };
            //if (slikaKontakta != null)
            //{
            //    kontakt.Slika = new byte[slikaKontakta.ContentLength];
            //    slikaKontakta.InputStream.Read(kontakt.Slika, 0, slikaKontakta.ContentLength);
            //}
            int privremeniBrojID = -1;

            foreach (BrojViewModel brojViewModel in kontaktViewModel.Brojevi)
            {
                Broj broj = new Broj()
                {
                    SadrzajBroja = brojViewModel.SadrzajBroja,
                    Opis = brojViewModel.Opis,
                    TipBroja = brojViewModel.TipBroja,
                    Status = brojViewModel.Status
                };

                if (brojViewModel.Status != Status.Dodano)
                    broj.BrojId = brojViewModel.BrojId;
                else
                {
                    broj.BrojId = privremeniBrojID;
                    privremeniBrojID--;
                }

                broj.KontaktId = kontaktViewModel.KontaktId;
                kontakt.Brojevi.Add(broj);
            }

            return kontakt;
        }
    }
}