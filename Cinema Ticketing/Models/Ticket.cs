using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Ticketing.Models
{
    internal class Ticket
    {
        public Ticket(string Name, decimal price)
        {
            Id = ++Counter;
            MovieName = Name;
            Price = price;
        }

        private static int Counter = 0;
        public int Id { get; }
        public string MovieName { get; set; }
        public decimal Price
        {
            get => field;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Price cannot be negative.");
                else
                    field = value;

            }
        }
        public decimal PriceAfterTax => Price * 1.14m;
        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price cannot be negative.");
            else
                Price = price;
        }
        public void SetPrice(decimal basePrice,decimal multiplier)
        {
            if (basePrice <= 0)
                throw new ArgumentException("Price cannot be negative.");
            else
                Price = basePrice * multiplier;
        }
        public virtual string PrintTicket()
        {
            string ticketInfo = $@"
Ticket ID: {Id}
Movie Name: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
";
            return ticketInfo;
        }
        public override string ToString()
        {
            string Info = $@"
MovieName: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
";
            return Info;
        }

        public static int GetTotalTickets() => Counter;
    }
}
