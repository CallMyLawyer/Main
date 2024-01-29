

namespace MehdiRahimiProject1.Classes;

public class Ticket
{
    public Ticket(string ticketName)
    {
        TicketName=ticketName;
    }

    public string TicketName { get; set; }
    public int Price{ get; set; }
    public int ChooseTicketType { get; set; }
    public int Id { get; set; }
    public TicketType TicketType { get; set; }
    public int PassengerId { get; set; }
}

public enum TicketType
{
    Bought = 1,
    Reserved = 2
}