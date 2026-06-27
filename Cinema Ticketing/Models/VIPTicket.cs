using Cinema_Ticketing.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal class VIPTicket : Ticket
    {
        public VIPTicket(string Name, decimal price) : base(Name, price) { }
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee = 50;


        public override string PrintTicket()
        {
            string ticketInfo = $@"
Ticket ID: {Id}
Movie Name: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
Lounge Access: {(LoungeAccess ? "Yes" : "No")}
Service Fee: {ServiceFee}
Ticet Type: VIP Ticket
Booked: {(IsBooked ? "Yes" : "No")}
";
            return ticketInfo;
        }
        public override decimal CalculateFinalPrice() => (Price + ServiceFee) * 1.14m;
        public override string ToString()
        {
            string Info = $@"
MovieName: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
Ticket Type: VIP
Lounge Access: {(LoungeAccess ? "Yes" : "No")}
";
            return Info;
        }

        public override object Clone()
        {
            // deep clone simple fields - MemberwiseClone is sufficient here
            var copy = (VIPTicket)this.MemberwiseClone();
            // primitive and string fields are copied; if there were reference fields, clone them here
            // reset booking state for the clone (new ticket not booked)
            copy.IsBooked = false;
            // assign a new unique id by invoking the constructor-like behavior
            // we cannot change Id (readonly), so for simplicity create new VIPTicket
            var newTicket = new VIPTicket(this.MovieName, this.Price)
            {
                LoungeAccess = this.LoungeAccess,
                ServiceFee = this.ServiceFee
            };
            return newTicket;
        }
    }
}
