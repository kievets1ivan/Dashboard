using DAL.Interfaces;

namespace DAL.Entities
{
    public class TicketEntity : IGenericEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
