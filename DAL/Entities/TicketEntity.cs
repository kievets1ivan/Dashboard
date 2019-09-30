using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DAL.Interfaces;

namespace DAL.Entities
{
    public class TicketEntity : IDeletable, IGenericModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter priority from 1 to 3")]
        [StringLength(1, ErrorMessage = "Please enter priority from 1 to 3")]
        public int Priority { get; set; }


        public string Theme { get; set; }
        public string Description { get; set; }
        public StatusTicket Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
