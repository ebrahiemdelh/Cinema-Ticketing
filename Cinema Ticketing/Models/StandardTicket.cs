using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_03.Models
{
    internal class StandardTicket:Ticket
    {
        public StandardTicket(string Name, decimal price,string seat) : base(Name, price) {
            SeatNumber = seat;
        }
        public string SeatNumber { get; set; }
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
