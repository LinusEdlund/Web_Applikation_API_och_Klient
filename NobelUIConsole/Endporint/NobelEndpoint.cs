using NobelUIConsole.DataAccess;
using NobelUIConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelUIConsole.Endporint;
public class NobelEndpoint
{
    private readonly INobelData _nobelData;

    public NobelEndpoint(INobelData nobelData)
    {
        _nobelData = nobelData;
    }

    public async Task CreatePerson()
    {
        Console.WriteLine("Enter the name:");
        string? name = Console.ReadLine();

        Console.WriteLine("Enter the year the person took the prize");
        string? yearString = Console.ReadLine();

        (bool isValid, int yearInt) = ValidatePerson(name, yearString);

        if (isValid)
        {
            await _nobelData.Create(new NobelModel
            {
                Name = name!,
                Year = yearInt
            });

            Console.WriteLine($"{name} was created!");
            return;
        }
        Console.WriteLine("Fail Try Again");
    }




    private (bool, int) ValidatePerson(string? name , string? yearString)
    {
        // om de har lagt in ett numer och det är mella 1900 till nu är isValidYear true annars blir det false
        bool isValidYear = int.TryParse(yearString, out int year) && year >= 1900 && year <= DateTime.Now.Year;

        bool isValidName = !string.IsNullOrEmpty(name) && name.Length >= 2;

        return (isValidYear &&  isValidName, year);
    }

   
}
