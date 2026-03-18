using Cinema_Ticketing.Models;
namespace Cinema_Ticketing;
public class Program
{
    public static void Main(string[] args)
    {
        Cinema cinema = new Cinema();
        cinema.Name = "CineMax";
        Console.WriteLine("=== Cinema Opened ===\n");
        cinema.OpenCinema();

        // Create tickets
        var standard = new StandardTicket("Inception",80.00m, "A5");
        var vip = new VIPTicket("Avengers",200.00m) { LoungeAccess = true };
        var imax = new IMAXTicket("Dune",130.00m, true);

        // Book all three
        standard.Book();
        vip.Book();
        imax.Book();

        cinema.AddTicket(standard);
        cinema.AddTicket(vip);
        cinema.AddTicket(imax);

        Console.WriteLine("\n--- All Tickets ---");
        cinema.PrintAllUsingInterface();

        // Clone VIP
        Console.WriteLine("\n--- Clone Test ---");
        var vipClone = (VIPTicket)vip.Clone();
        // change movie name on clone
        vipClone.MovieName = "Interstellar";

        Console.Write("Original : ");
        vip.Print();
        Console.Write("Clone    : ");
        vipClone.Print();

        // Cancel one ticket
        Console.WriteLine("\n--- After Cancellation ---");
        standard.Cancel();
        standard.Print();

        // BookingHelper print
        Console.WriteLine("\n--- BookingHelper.PrintAll ---");
        var printable = new Cinema_Ticketing.Services.Interface.IPrintData[] { standard, vip, imax };
        Cinema_Ticketing.Services.BookingHelper.PrintAll(printable);

        cinema.CloseCinema();
        Console.WriteLine("\n=== Cinema Closed ===");
    }
}