using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_03.Models
{
    internal class Ticket
    {
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
        public Ticket(string Name, decimal price)
        {
            Id = ++Counter;
            MovieName = Name;
            Price = price;
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
