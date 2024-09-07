using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TicketResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public int PriorityId { get; set; }
    public string PriorityName { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public int TicketTypeId { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public DateTime DeadLine { get; set; }
}
