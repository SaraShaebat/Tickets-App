﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }

}
