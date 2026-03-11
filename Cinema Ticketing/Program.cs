using Cinema_Ticketing.Models;
namespace Cinema_Ticketing;
public class Program
{
    public static void Main(string[] args)
    {
        Cinema cinema = new Cinema();
        cinema.Name = "CineMax";
        cinema.OpenCinema();
        Ticket standard = new StandardTicket("Inception",10.00m, "A1");
        Ticket vip = new VIPTicket("Inception",10.00m);
        Ticket imax = new IMAXTicket("Inception",10.00m, true);
        standard.SetPrice(15.00m);
        standard.SetPrice(20.00m,1.2m);
        cinema.AddTicket(standard);
        cinema.AddTicket(vip);
        cinema.AddTicket(imax);
        Console.WriteLine(cinema.PrintAllTickets());
        Cinema.ProcessTicket(standard);
        cinema.CloseCinema();

    }
}