using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal partial class Cinema
    {
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

        public static void ProcessTicket(Ticket t)
        {
            Console.WriteLine(t.PrintTicket());
        }
        public Ticket this[int index]
        {
            get
            {
                if (index < 0 || index >= 20) return null;
                return Tickets[index];
            }
            set
            {
                if (index < 0 || index >= 20) return;
                Tickets[index] = value;
            }
        }
        public Ticket GetMovieByName(string movieName)
        {
            for (int i = 0; i < TicketCount; i++)
            {
                if (Tickets[i] != null && Tickets[i].MovieName == movieName)
                    return Tickets[i];
            }
            return null;
        }
    }
}
