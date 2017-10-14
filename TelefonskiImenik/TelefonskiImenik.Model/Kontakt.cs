namespace TelefonskiImenik.Model
{
    public class Kontakt
    {
        public int KontaktId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Opis { get; set; }
        public int Slika { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
    }
}
