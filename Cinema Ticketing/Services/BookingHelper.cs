using System;
using Cinema_Ticketing.Services.Interface;

namespace Cinema_Ticketing.Services
{
    internal static class BookingHelper
    {
        public static void PrintAll(IPrintData[] items)
        {
            foreach (var it in items)
            {
                it.Print();
            }
        }
        private static int _bookingCounter = 0;

        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;
            if (numberOfTickets >= 5)
                total *= 0.90;
            return total;
        }

        public static string GenerateBookingReference()
        {
            _bookingCounter++;
            return $"BK-{_bookingCounter}";
        }
    }
}
