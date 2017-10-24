using TelefonskiImenik.Model;

namespace TelefonskiImenik.Web.ViewModels
{
    public class BrojViewModel : IStatusi
    {
        public int BrojId { get; set; }
        public string SadrzajBroja { get; set; }
        public string TipBroja { get; set; }
        public string Opis { get; set; }
        public int KontaktId { get; set; }
        public Status Status { get; set; }
    }
}