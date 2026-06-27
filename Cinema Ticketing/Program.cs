using Cinema_Ticketing.Models;
using Cinema_Ticketing.Services;
namespace Cinema_Ticketing;

public class Program
{
    public static void Main(string[] args)
    {
        Cinema cinema = new Cinema() { Name = "CineMax" };
        Console.WriteLine("=== Cinema Opened ===\n");
        cinema.OpenCinema();

        // Create tickets
        var standard = new StandardTicket("Inception", 80.00m, "A5");
        var vip = new VIPTicket("Avengers", 200.00m) { LoungeAccess = true };
        var imax = new IMAXTicket("Dune", 130.00m, true);

        // Book all three
        standard.Book();
        vip.Book();
        imax.Book();

        cinema.AddTicket(standard);
        cinema.AddTicket(vip);
        cinema.AddTicket(imax);

        Console.WriteLine("\n--- All Tickets ---");
        cinema.PrintAllUsingInterface();

        // Polymorphism
        Console.WriteLine("\n--- Polymorphism: Final Price per Ticket ---");
        Ticket[] tickets = { standard, vip, imax };
        foreach (Ticket ticket in tickets)
        {
            Console.WriteLine($"{ticket.GetType().Name} => Final Price: {ticket.CalculateFinalPrice():F2}");
        }

        // Extension - receipt
        Console.WriteLine("--- Extension Method: Receipt ---");
        Console.WriteLine(vip.ToReceipt());
        Console.WriteLine();

        // Extension method — total revenue
        Console.WriteLine("--- Extension Method: Total Revenue ---");
        Console.WriteLine($"Total Revenue: {tickets.TotalRevenue():F2}");
        Console.WriteLine();

        cinema.CloseCinema();
        Console.WriteLine("\n=== Cinema Closed ===");
    }
}