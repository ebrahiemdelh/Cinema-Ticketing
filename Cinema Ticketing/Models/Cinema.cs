using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal partial class Cinema
    {
        public string Name { get; set; }
        public Projector Projector { get; set; } = new Projector();
        public Ticket[] Tickets { get; set; } = new Ticket[20];
        public int TicketCount { get; set; } = 0;
    }
}
