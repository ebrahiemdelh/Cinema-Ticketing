using Cinema_Ticketing.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal partial class Cinema
    {
        public string PrintAllTickets()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cinema: {Name}");
            sb.AppendLine("Tickets:");
            for (int i = 0; i < TicketCount; i++)
            {
                sb.AppendLine(Tickets[i].PrintTicket());
                sb.AppendLine("-----------------------------");
            }
            return sb.ToString();
        }

        public void PrintAllUsingInterface()
        {
            for (int i = 0; i < TicketCount; i++)
            {
                if (Tickets[i] is IPrintData printable)
                    printable.Print();
                else
                    Console.WriteLine(Tickets[i].PrintTicket());
            }
        }
    }
}
