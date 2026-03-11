using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal class StandardTicket:Ticket
    {
        public StandardTicket(string Name, decimal price,string seat) : base(Name, price) {
            SeatNumber = seat;
        }
        public string SeatNumber { get; set; }

        public override string PrintTicket()
        {
            string ticketInfo = $@"
Ticket ID: {Id}
Movie Name: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
Seat Number: {SeatNumber}
Ticet Type: Standard Ticket
";
            return ticketInfo;
        }
        public override string ToString()
        {
            string Info = $@"
MovieName: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
Ticket Type: Standard
";
            return Info;
        }
    }
}
