using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TicketDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; } // FK
    public int PriorityId { get; set; } // FK
    public int CompanyId { get; set; } // FK
    public int TicketTypeId { get; set; } // FK
    public int ServiceId { get; set; } // FK
    public DateTime DeadLine { get; set; }
}
