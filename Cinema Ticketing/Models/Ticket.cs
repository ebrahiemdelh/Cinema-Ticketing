using Cinema_Ticketing.Services.Interface;

namespace Cinema_Ticketing.Models
{
    internal abstract class Ticket : IPrintData, IBookable, ICloneable
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
        public decimal PriceAfterTax => CalculateFinalPrice();

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

        // Add this new abstract method
        public abstract decimal CalculateFinalPrice();

        // PrintTicket stays virtual as before
        public virtual string PrintTicket()
        {
            return $@"
Ticket ID: {Id}
Movie Name: {MovieName}
Price: {Price}
Price After Tax: {CalculateFinalPrice()}
Booked: {(IsBooked ? "Yes" : "No")}
";
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
            return MemberwiseClone();
        }
    }
}
