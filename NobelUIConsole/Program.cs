﻿// See https://aka.ms/new-console-template for more information
using NobelUIConsole.DataAccess;
using NobelUIConsole.Endporint;
using Refit;



INobelEndpoint nobel = new NobelEndpoint(RestService.For<INobelData>("https://localhost:7117"));


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
            await nobel.Read();
            break;

        case ConsoleKey.D2:
            await nobel.Create();
            break;

        case ConsoleKey.D3:
            await nobel.Update();
            break;

        case ConsoleKey.D4:
            await nobel.Delete();
            break;

        case ConsoleKey.D9:
            return;

        default:
            Console.WriteLine("Invalid key.");
            break;
    }

}