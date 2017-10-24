namespace TelefonskiImenik.Model
{
    public interface IStatusi
    {
        Status Status { get;set; } 
    }
    public enum Status
    {
        Nepromijenjeno = 0,
        Dodano = 1,
        Promijenjeno = 2,
        Izbrisano = 3
    }

}
