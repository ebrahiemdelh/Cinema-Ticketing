using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_03.Models
{
    internal class Cinema
    {
        public string Name { get; set; }
        public Projector Projector { get; set; } = new Projector();
        public Ticket[] Tickets { get; set; } = new Ticket[20];
        public int TicketCount { get; set; } = 0;

        public void AddTicket(Ticket ticket)
        {
            if (TicketCount < 20)
            {
                Tickets[TicketCount] = ticket;
                TicketCount++;
                Console.WriteLine("Ticket added successfully.");
                Console.WriteLine($"Total Tickets: {TicketCount}");
            }
            else
            {
                Console.WriteLine("Cinema ticket limit reached.");
            }
        }
        public string PrintAllTickets()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cinema: {Name}");
            sb.AppendLine("Tickets:");
            for (int i = 0; i < TicketCount; i++)
            {
                sb.AppendLine(Tickets[i].ToString());
            }
            return sb.ToString();
        }
        public void OpenCinema()
        {
            Projector.Start();
            Console.WriteLine($"{Name} is now open.");
        }
        public void CloseCinema()
        {
            Projector.Stop();
            Console.WriteLine($"{Name} is now Closed.");
        }
    }
}
