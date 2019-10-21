using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        //on contraccts
        //[Required(ErrorMessage = "Please enter priority from 1 to 3")]
        //[StringLength(1, ErrorMessage = "Please enter priority from 1 to 3")]
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}