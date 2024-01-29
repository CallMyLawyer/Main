using MehdiRahimiProject1;
using MehdiRahimiProject1.Classes;

while (true)
{
    try
    {
            Run();
    }
    catch(Exception exception)
    {
        ShowError(exception.Message);
    }  
}

static void Run()
{
    Console.WriteLine("-----Menu-----\n1.Add New Buss\n2.Take A Trip\n3.Show Detail Of Buss\n4.Cancel The Ticket");
    var option = int.Parse(Console.ReadLine()!);
    switch (option)
    {
        case 1 :
            var name = GetString("Enter The Buss Name:");
            var setTypeOfBuss = GetInt("Enter The Type Of Buss:\n0.Not Vip\n1.Vip");
            var origin = GetString("Enter The Origin Of Buss:");
            var destination = GetString("Enter The Destination Of Buss:");
            var ticketPrice = GetInt("Enter The Ticket Price:");
            Managment.AddNewBuss(name ,origin,destination,setTypeOfBuss, ticketPrice);
            break;
        case 2:
            var passengerFirstName = GetString("Enter Ur First Name:");
            var passengerLastName = GetString("Enter Your Last Name:");
            var bussType = GetInt("Enter The Type Of Trip:\n0.Not Vip\n1.Vip");
            Managment.ShowBusses(bussType);
            var bussName = GetString("Enter The Buss Name:");
            var ticket = GetInt("Choose How Do You Want To Get Your Ticket:" +
                                "\n1.Reserve\n2.Buy");
            Managment.ShowBussSeat(bussName);
            var seat = GetString("Enter The Seat Number Number:");
            Managment.TakeSeat(bussName,seat,ticket);
            Managment.FindPrice(bussName);
            var payment = GetInt("Enter The Price Of Ticket:");
            Managment.BuyTicket(passengerFirstName,passengerLastName,bussName , ticket ,payment );
            break;
            case 3:
            bussName = GetString("Enter The Buss Name");
            Managment.ShowBussDetail(bussName);
            break;
            case 4:
            Console.WriteLine("Enter 3 To Cancel The Method And Get Back To Menu!!");
            var ticketType = GetInt("Enter The Ticket Type:\n1.Reserved Ticket/n2.Bought Ticket");
            bussName = GetString("Enter The Buss Name:");
            var buyerFirstName = GetString("Enter Ur First Name:");
            var buyerLastName = GetString("Enter Ur Last Name:");
            var seatIndex = GetInt("Enter Ur Seat:");
            Managment.CancelTheTicket(ticketType,bussName,buyerFirstName,buyerLastName,seatIndex);
                break;
            
    }
}
static string GetString(string message)
{
    Console.WriteLine(message);
    var value = Console.ReadLine()!;
    return value;
}
static int GetInt(string message)
{
    Console.WriteLine(message);
    var value = int.Parse(Console.ReadLine()!);
    return value;
}
static string ShowError(string error)
{
    Console.WriteLine(error);
    return error;
}