using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsCustomer { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Service> Services { get; set; }

    }

}
