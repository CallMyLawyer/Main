using System.Collections;
using Azure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MehdiRahimiProject1.Classes;

public class Buss : IEnumerable
{
    public List<Ticket> CancelTickets = new();
    public List<Ticket> SoldTickets = new();
    public List<Ticket> ReservedTickets = new();
    public HashSet<Passenger> Passengers = new();
    public List<string> SeatCapacity = new(); 
    public Buss(string name , string origin , string destination , int ticketPrice )
    {
        Name = name;
        Origin = origin;
        Destination = destination;
        TicketPrice = ticketPrice;
    }
    public int SoldTicketCount { get; set; }
    public int SoldTicketPrice { get; set; }
    public int ReservedTicketCount { get; set; }
    public int TicketPrice { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public TypeOfBuss BussType { get; set; }
    public int SetTypeOfBuss { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Capacity { get; set; }
    public int SoldTicketsIncome { get; set; }
    public int ReservedTicketsIncome { get; set; }
    public int CancelSoldTickets { get; set; }
    public int CancelReservedTickets { get; set; }
    public IEnumerator GetEnumerator()
    
    {
        throw new NotImplementedException();
    }
}