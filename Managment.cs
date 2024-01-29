using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;
using MehdiRahimiProject1.Classes;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace MehdiRahimiProject1;

public static class Managment


{
    public static List<Buss> Busses = new();

    public static void AddNewBuss(string name, string origin, string destination,
        int setTypeOfBuss, int ticketPrice)
    
    {
        Buss buss = new(name, origin, destination, ticketPrice);
        if (setTypeOfBuss == 0)
        {
            buss.BussType = TypeOfBuss.NotVip;
            buss.Capacity = 44;
            for (int i = 1; i <= buss.Capacity; i++)
            {
                buss.SeatCapacity.Add(i.ToString());
            }
        }

        if (setTypeOfBuss == 1)
        {
            buss.BussType = TypeOfBuss.Vip;
            buss.Capacity = 30;
            for (int i = 1; i <= buss.Capacity; i++)
            {
                buss.SeatCapacity.Add(i.ToString());
            }
        }

        if (setTypeOfBuss >3)
        {
            throw new Exception("Wrong Buss Type!");
        }

        if (setTypeOfBuss < 0)
        {
            throw new Exception("Wrong Buss Type!");
        }

        if (ticketPrice <= 0)
        {
            throw new Exception("Invalid Ticket Price!");
        }

        Busses.Add(buss);
    }

    public static void ShowBusses(int bussType)
    {
        if (bussType==3)
        {
            throw new Exception("-----Menu-----");
        }
        if (bussType == 0)
        {
            var busses = Managment.Busses.FindAll(_ => _.BussType == TypeOfBuss.NotVip);
            foreach (var buss in busses)
            {
                Console.WriteLine($"Name : {buss.Name} | Capacity : {buss.Capacity}" +
                                  $" | Origin : {buss.Origin} | Destination : {buss.Destination}" +
                                  $" | Ticket Price : {buss.TicketPrice} Dollars");
            }
        }

        if (bussType == 1)
        {
            var busses = Managment.Busses.FindAll(_ => _.BussType == TypeOfBuss.Vip);
            foreach (var buss in busses)
            {
                Console.WriteLine($"Name : {buss.Name} | Capacity : {buss.Capacity}" +
                                  $" | Origin : {buss.Origin} | Destination : {buss.Destination}" +
                                  $" | Ticket Price : {buss.TicketPrice} Dollars");
            }
        }
    }

    public static void FindPrice(string bussName)
    {
        if (bussName=="3")
        {
            throw new Exception("-----Menu-----");
        }
        var buss = Busses.Find(_ => _.Name == bussName);
        if (Busses.Exists(_ => _.Name == bussName))
        {
            var reservePrice = buss.TicketPrice * 30 /100;
            Console.WriteLine($"Ticket Buy Price : {buss.TicketPrice}");
            Console.WriteLine($"Ticket Reserve Price : {reservePrice}");

        }
        else
        {
            throw new Exception("The Buss Does Not Exist!");
        }
    }

    public static void ShowBussSeat(string bussName)
    {
        if (bussName=="3")
        {
            throw new Exception("-----Menu-----");
        }
        if (Busses.Exists(_ => _.Name == bussName))
        {
            var buss = Busses.Find(_ => _.Name == bussName);
            foreach (var item in buss.SeatCapacity)
            {
                Console.WriteLine(item);
            }
        }
    }

    public static void BuyTicket(string passengerFirstName
        , string passengerLastName, string bussName,
        int ticket, int payment)
    {
        if (bussName=="3")
        {
            throw new Exception("-----Menu-----");
        }
        Passenger passenger = new(passengerFirstName, passengerLastName);
        var ticketName = passenger.FirstName + " " + passenger.LastName;
        Ticket newTicket = new(ticketName);
        if (Busses.Exists(_ => _.Name == bussName))
        {
            var buss = Busses.Find(_ => _.Name == bussName);
            newTicket.Price = buss.TicketPrice;
            int receipt = newTicket.Price;
            buss.Passengers.Add(passenger);
            if (ticket==3)
            {
                throw new Exception("-----Menu-----");
            }
            if (ticket == 1)
            {
                if (payment == ((receipt*30)/100))
                {
                    newTicket.TicketType = TicketType.Reserved;
                    buss.ReservedTickets.Add(newTicket);
                    passenger.Tickets.Add(newTicket);
                    var bussCapacity = buss.Capacity - 1;
                    buss.Capacity = bussCapacity;
                    receipt = buss.TicketPrice * 30 / 100;
                    buss.ReservedTicketCount = buss.ReservedTicketCount + 1;

                }
                else
                {
                    throw new Exception("Invalid Payment!");
                }
            }

            if (ticket == 2)
            {
                receipt = buss.TicketPrice;
                if (payment == receipt)
                {
                    newTicket.TicketType = TicketType.Bought;
                    buss?.SoldTickets.Add(newTicket);
                    passenger.Tickets.Add(newTicket);
                    var bussCapacity = buss.Capacity - 1;
                    buss.Capacity = bussCapacity;
                    buss.TicketPrice = receipt;
                    buss.SoldTicketCount = buss.SoldTicketCount + 1;


                }
                else
                {
                    throw new Exception("Invalid Payment!");
                }
            }

        }
        else
        {
            throw new Exception("The Buss Does Not Exist!");
        }
    }

    public static void TakeSeat(string bussName, string seat , int ticket)
    {
        if (bussName=="3")
        {
            throw new Exception("-----Menu-----");
        }
        if (Busses.Exists(_ => _.Name == bussName))
        {
            var buss = Busses.Find(_ => _.Name == bussName);
            var seatIndex = buss.SeatCapacity.IndexOf(seat);
            var seatExist = buss.SeatCapacity.First(_=>_.Contains(seatIndex.ToString()));
            if (ticket==3)
            {
                throw new Exception("-----Menu-----");
            }
            if (ticket==1)
            {
                if (buss.SeatCapacity.Contains(seat))
                {
                    if (seatExist.Contains("rr"))
                    {
                        throw new Exception("The Seat Has Been Reserved By Another Traveler! " +
                                            "Please Choose Another Seat!");
                    }
                    if (seatExist.Contains("bb"))
                    {
                        throw new Exception(" Seat Number Has Bought By Another Traveler! " +
                                            "Please Choose Another Seat!");
                    }
                    else
                    {
                        seatIndex = buss.SeatCapacity.IndexOf(seat); 
                        buss.SeatCapacity.Remove((seatIndex + 1).ToString());
                        buss.SeatCapacity.Insert(seatIndex  , "rr"); 
                    }
  
                }

            }

            if (ticket==2)
            {
                if (buss.SeatCapacity.Contains(seat))
                {
                    if (seatIndex.ToString()=="bb")
                    {
                        throw new Exception(" Seat Number Is Full!");
                    }

                    if (seatIndex.ToString() =="rr")
                    {
                        throw new Exception("Seat Number Is Full!");
                    }
                    seatIndex = buss.SeatCapacity.IndexOf(seat);
                    buss.SeatCapacity.Remove((seatIndex + 1).ToString());
                    buss.SeatCapacity.Insert(seatIndex  , "bb");
                }

            }
        }
        else
        {
            throw new Exception("Invalid BussName!");
        }
    }

    public static void ShowBussDetail(string bussName)
    {
        if (bussName=="3")
        {
            throw new Exception("-----Menu-----");
        }
        if (Busses.Exists(_ => _.Name == bussName))
        {
            var buss = Busses.Find(_ => _.Name == bussName);
            Console.WriteLine("-----Busses Details-----");
            foreach (var bussDetail in Busses)
            {
                Console.WriteLine($"Name = {bussDetail.Name} | BussType : {bussDetail.BussType} | " +
                                  $"CapacityLeft : {bussDetail.Capacity} | " +
                                  $"Origin = {bussDetail.Origin} | Destination = {bussDetail.Destination} " +
                                  $"| SoldTicketsCount = {bussDetail.SoldTicketCount} | ReservedTicketCount" +
                                  $" : {bussDetail.ReservedTicketCount}");
            }

            Console.WriteLine($"Buss {buss.Name} Seats:");
            foreach (var item in buss.SeatCapacity)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"{buss.Name} Buss ReservedTicketsDetail:");
            foreach (var ticket in buss.ReservedTickets)
            {
                Console.WriteLine($"Name : {ticket.TicketName} |" +
                                  $" TicketType : {ticket.TicketType} | " +
                                  $"TicketPrice : {ticket.Price} | " +
                                  $"Receipt Amount : {ticket.Price*30/100} | " +
                                  $"Payment Amount Left : {ticket.Price*70/100}");
            }

            Console.WriteLine($"{buss.Name} Buss SoldTicketsDetail:");
            foreach (var ticket in buss.SoldTickets)
            {
                Console.WriteLine(
                    $"Name : {ticket.TicketName} | TicketType : {ticket.TicketType} | " +
                    $"TicketPrice : {ticket.Price} | Payment : Paid In Full!");
            }

            buss.SoldTicketsIncome = buss.SoldTicketCount * buss.TicketPrice;
            buss.ReservedTicketsIncome = buss.ReservedTicketCount * (buss.TicketPrice*30) / 100 ;
            Console.WriteLine("-----Sold And Reserved Tickets Income-----");
            
            Console.WriteLine($"Total Income : {buss.SoldTicketsIncome + buss.ReservedTicketsIncome }\n" +
                              $"Sold Tickets Income Only : {buss.SoldTicketsIncome}\n" +
                              $"Reserved Tickets Income Only {buss.ReservedTicketsIncome}");

            Console.WriteLine("-----Cancel Tickets Income-----");
            Console.WriteLine($"Total Cancelling Income : {buss.CancelReservedTickets * (buss.TicketPrice * 6 / 100) 
                                                           + buss.CancelSoldTickets * (buss.TicketPrice * 10 / 100)} |" +
                              $"\n Cancelling Only Sold Tickets Income : " + 
                              $"\n {buss.CancelSoldTickets * (buss.TicketPrice * 10 / 100)} | " +
                              $"\n Cancelling Only Reserved Tickets Income :" +
                              $" {buss.CancelReservedTickets * (buss.TicketPrice *6/100)}");
            Console.WriteLine("-----Cancel Tickets Detail-----");
            foreach (var ticket in buss.CancelTickets)
            {
                Console.WriteLine($"Ticket Name : {ticket.TicketName} | " +
                                  $"Ticket Price : {ticket.Price} | " +
                                  $"Ticket Type : {ticket.TicketType}");
            }
            Console.WriteLine($"\nAll Income : {(buss.SoldTicketsIncome + buss.ReservedTicketsIncome) +
                                                (buss.CancelReservedTickets * (buss.TicketPrice * 6/ 100) 
                                                 + buss.CancelSoldTickets * (buss.TicketPrice * 10 / 100))}");
        }
   
        else

        {
            throw new Exception("Invalid Buss Name! ");
        }
    }

    public static void CancelTheTicket(int ticketType, string bussName,
        string buyerFirstName, string buyerLastName, int seatIndex)
    {
        if (ticketType==3)
        {
            throw new Exception("-----Menu-----");
        }
        if (ticketType==1)
        {
            if (Busses.Exists(_ => _.Name == bussName))
            {
                var buss =Busses.Find(_ => _.Name == bussName);
                Ticket buyerName = buss.ReservedTickets.Find
                    (_=>_.TicketName==(buyerFirstName +" "+buyerLastName));
                var ticket = buss.ReservedTickets.Find(_ => _.TicketName == buyerName?.TicketName);
                if (buss.ReservedTickets.Exists(_=>_.TicketName==buyerName?.TicketName))
                {
                    var bussTicketPrice = buss.TicketPrice *30/100;
                    bussTicketPrice = bussTicketPrice *20/100;
                    buss.ReservedTicketsIncome = buss.ReservedTicketsIncome + bussTicketPrice;
                    buss.CancelReservedTickets = buss.CancelReservedTickets + 1;
                    buss.CancelTickets.Add(ticket);
                    buss.ReservedTicketCount= buss.ReservedTicketCount- 1;
                    buss.ReservedTickets.Remove(ticket);
                    Console.WriteLine("success!");
                }
            }

        }
        if (ticketType==2)
        {
            if (Busses.Exists(_ => _.Name == bussName))
            {
                var buss =Busses.Find(_ => _.Name == bussName);
                Ticket? buyer = buss.SoldTickets.Find
                    (_=>_.TicketName==(buyerFirstName +" "+buyerLastName));
                var ticket = buss.SoldTickets.Find(_ => _.TicketName == buyer?.TicketName);
                if (buss.SoldTickets.Exists(_=>_.TicketName==buyer?.TicketName))
                {
                    var bussTicketPrice = buss.TicketPrice* 10/100;
                    buss.ReservedTicketsIncome = buss.ReservedTicketsIncome + bussTicketPrice;
                    buss.CancelSoldTickets = buss.CancelSoldTickets+ 1;
                    buss.CancelTickets.Add(ticket);
                    buss.SoldTicketCount= buss.SoldTicketCount- 1;
                    buss.SoldTickets.Remove(ticket);
                    Console.WriteLine("Success!");
                    buss.Capacity= buss.Capacity + 1;
                    string removeSeat= "bb";
                    buss.SeatCapacity.IndexOf(removeSeat.Remove(seatIndex));
                    buss.SeatCapacity.Insert(seatIndex , seatIndex.ToString());

                }
            }

        }
    }
}
