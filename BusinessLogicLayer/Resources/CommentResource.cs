﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Resources
{
    public class CommentResource()
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string CommentText { get; set; }
    }

}
