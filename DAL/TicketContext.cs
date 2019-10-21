using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class TicketContext : DbContext
    {
        public TicketContext()
            : base("Connection")
        {

        }

        public DbSet<TicketEntity> TicketEntities { get; set; }

        public static TicketContext Create() => new TicketContext();
    }
}
