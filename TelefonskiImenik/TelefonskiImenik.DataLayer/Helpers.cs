using System.Data.Entity;
using TelefonskiImenik.Model;
namespace TelefonskiImenik.DataLayer
{
    public static class Helpers
    {
        public static EntityState PromijeniStatus(Status status)
        {
            switch (status)
            {
                case Status.Dodano:
                    return EntityState.Added;
                case Status.Promijenjeno:
                    return EntityState.Modified;
                case Status.Izbrisano:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IStatusi>())
            {
                IStatusi stateInfo = entry.Entity;
                entry.State = PromijeniStatus(stateInfo.Status);
            }
        }
    }
}
