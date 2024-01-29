using System.Reflection.Metadata.Ecma335;

namespace MehdiRahimiProject1.Classes;

public class Passenger
{
    public List<Ticket> Tickets = new();
    public Passenger(string firstName , string lastName )
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public int BussId { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PassengerSeat { get; set; }
    public TypeOfBuss PassengerType { get; set; }
}

public enum TypeOfBuss
{
    NotVip = 0,
    Vip = 1
}