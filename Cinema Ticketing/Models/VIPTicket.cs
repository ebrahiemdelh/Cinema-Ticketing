using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_03.Models
{
    internal class VIPTicket : Ticket
    {
        public VIPTicket(string Name, decimal price) : base(Name, price) { }
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee = 50;

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
    }
}
