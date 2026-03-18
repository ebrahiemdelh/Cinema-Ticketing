using Cinema_Ticketing.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal class IMAXTicket : Ticket
    {
        private bool Is3d;
        public IMAXTicket(string Name, decimal price, bool Is3d) : base(Name, price)
        {
            if (Is3d)
                Price += 20;
            this.Is3d = Is3d;
        }

        public override string PrintTicket()
        {
            string ticketInfo = $@"
Ticket ID: {Id}
Movie Name: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
IS 3D: {(Is3d ? "Yes" : "No")}
Ticet Type: IMAX Ticket
Booked: {(IsBooked ? "Yes" : "No")}
";
            return ticketInfo;
        }
        public void Print()
        {
            Console.WriteLine(PrintTicket());
        }

        public override string ToString()
        {
            string Info = $@"
MovieName: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
Ticket Type: IMAX
Is 3D: {(Is3d ? "Yes" : "No")}
";
            return Info;
        }

    }
}
