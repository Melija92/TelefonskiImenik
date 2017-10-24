namespace TelefonskiImenik.Model
{
    public class Broj : IStatusi
    {
        public int BrojId { get; set; }
        public string SadrzajBroja { get; set; }
        public string TipBroja { get; set; }
        public string Opis { get; set; }
        public int KontaktId { get; set; }
        public Kontakt Kontakt { get; set; }
        public Status Status { get; set; }
    }
}
