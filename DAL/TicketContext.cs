using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class TicketContext : DbContext
    {
        public TicketContext()
            : base("Connection") { }

        public DbSet<TicketEntity> TicketEntities { get; set; }

        public override int SaveChanges()
        {

            foreach (var x in ChangeTracker
                .Entries<IDeletable>()
                .Where(e => e.State == EntityState.Deleted))
            {
                x.Entity.IsDelete = true;
                x.State = EntityState.Modified;

            }

            return base.SaveChanges();
        }
    }
}
