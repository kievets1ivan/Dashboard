using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum StatusTicket
    {
        OnHold = 1,
        ToDo = 2,
        InProgress = 3,
        CodeReview = 4,
        Done = 5,
        Verified = 6
    }
}
