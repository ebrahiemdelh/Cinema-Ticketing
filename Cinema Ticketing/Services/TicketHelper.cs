using Cinema_Ticketing.Models;

namespace Cinema_Ticketing.Services
{
    internal static class TicketHelper
    {
        public static string ToReceipt(this Ticket ticket)
        {
            return $@"========== RECEIPT ==========
  Movie    : {ticket.MovieName}
  Type     : {ticket.GetType().Name}
  Price    : {ticket.Price}
  Final    : {ticket.CalculateFinalPrice():F2}
  Status   : {(ticket.IsBooked ? "Booked" : "Not Booked")}
=============================";
        }

        public static decimal TotalRevenue(this Ticket[] tickets)
        {
            decimal total = 0;
            foreach (var t in tickets)
                total += t.CalculateFinalPrice();
            return total;
        }
    }
}
