using System;
using System.Collections.Generic;
using System.Text;
using Cinema_Ticketing.Services.Interface;

namespace Cinema_Ticketing.Models
{
    internal class Ticket : IPrintData, IBookable, ICloneable
    {
        public Ticket(string Name, decimal price)
        {
            Id = ++Counter;
            MovieName = Name;
            Price = price;
            IsBooked = false;
        }

        private static int Counter = 0;
        public int Id { get; }
        public string MovieName { get; set; }
        private decimal field;
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

        // Booking implementation
        public bool IsBooked { get; protected set; }
        public bool Book()
        {
            if (IsBooked)
                return false;
            IsBooked = true;
            return true;
        }
        public bool Cancel()
        {
            if (!IsBooked)
                return false;
            IsBooked = false;
            return true;
        }

        // Printing
        public virtual string PrintTicket()
        {
            string ticketInfo = $@"
Ticket ID: {Id}
Movie Name: {MovieName}
Price: {Price}
Price After Tax: {PriceAfterTax}
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
";
            return Info;
        }

        public static int GetTotalTickets() => Counter;

        // ICloneable implementation - shallow by default; derived classes may override
        public virtual object Clone()
        {
            // MemberwiseClone is fine for primitive fields; derived classes should deep clone if needed
            return this.MemberwiseClone();
        }
    }
}
