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
    }
}
