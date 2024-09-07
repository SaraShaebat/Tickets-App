using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class TicketType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }

}
