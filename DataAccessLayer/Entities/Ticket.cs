using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; } // FK
        public int PriorityId { get; set; } // FK
        public int CompanyId { get; set; } // FK
        public int TicketTypeId { get; set; } // FK
        public int ServiceId { get; set; } // FK
        public DateTime DeadLine { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Company Company { get; set; }

        public Priority Priority { get; set; }

        public TicketType TicketType { get; set; }


        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Service Service { get; set; }

        public Status Status { get; set; }
        public ICollection<UserTicket> UserTickets { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}
