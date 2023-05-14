// See https://aka.ms/new-console-template for more information
using NobelUIConsole.DataAccess;
using NobelUIConsole.Endporint;
using Refit;



NobelEndpoint nobel = new(RestService.For<INobelData>("https://localhost:7117"));


while (true)
{
    Console.WriteLine("Press enter to continue");
    Console.ReadKey();

    Console.Clear();
    Console.WriteLine("1: View Noble Prize Takers");
    Console.WriteLine("2: Create a new nobel prize taker");
    Console.WriteLine("3: Update a person");
    Console.WriteLine("4: Delete a person");
    Console.WriteLine("9: Exit");
    ConsoleKey key = Console.ReadKey().Key;

    Console.WriteLine();

    switch (key)
    {
        case ConsoleKey.D1:
            break;
        case ConsoleKey.D2:
            await nobel.CreatePerson();
            break;
        case ConsoleKey.D3:
            break;
        case ConsoleKey.D4:
            break;
        case ConsoleKey.D9:
            return;

        default:
            Console.WriteLine("Invalid key.");
            break;
    }

}