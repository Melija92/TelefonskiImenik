using System.Collections.Generic;
using TelefonskiImenik.Model;

namespace TelefonskiImenik.Web.ViewModels
{
    public class KontaktViewModel : IStatusi
    {
        public KontaktViewModel()
        {
            Brojevi = new List<BrojViewModel>();
            BrojeviZaBrisanje = new List<int>();
        }
        public int KontaktId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int GradId { get; set; }

        public virtual ICollection<Grad> Grad { get; set; }

        public string NazivGrada { get; set; }

        public Status Status { get; set; }
        public List<BrojViewModel> Brojevi { get; set; }
        public List<int> BrojeviZaBrisanje { get; set; }
    }
}