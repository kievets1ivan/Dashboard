using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO
{
    public class TicketDtoService
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public StatusTicket Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
