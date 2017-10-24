using System.Collections.Generic;

namespace TelefonskiImenik.Model
{
    public class Kontakt : IStatusi
    {
        public Kontakt()
        {
            Brojevi = new List<Broj>();
        }


        public int KontaktId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public Status Status { get; set; }
        public virtual List<Broj> Brojevi { get; set; }
    }
}
