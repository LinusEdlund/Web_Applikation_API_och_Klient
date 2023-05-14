using NobelUIConsole.DataAccess;
using NobelUIConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NobelUIConsole.Endporint;
public class NobelEndpoint : INobelEndpoint
{
    private readonly INobelData _nobelData;

    public NobelEndpoint(INobelData nobelData)
    {
        _nobelData = nobelData;
    }

    public async Task Read()
    {
        List<NobelModel> nobels = await _nobelData.GetAll();
        nobels.ForEach(x =>
            Console.WriteLine($"Id: {x.Id} Name: {x.Name} Year: {x.Year}"));
    }

    public async Task Create()
    {
        string? name = CreateName();

        (bool isValid, int yearInt) = ValidatePerson(name, CreateYear());

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

    public async Task Update()
    {
        NobelModel chosenPerons = new();
        await Read();

        Console.WriteLine("What person do u want to update? Enter id");
        string? idString = Console.ReadLine();
        bool isValidId = int.TryParse(idString, out int id);

        if (isValidId == false)
        {
            Console.WriteLine("Fail Try Again");
            return;
        }

        try
        {
            chosenPerons = await _nobelData.GetById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        Console.WriteLine();
        Console.WriteLine($"Id: {chosenPerons.Id} Name: {chosenPerons.Name} Year: {chosenPerons.Year}");

        string? name = CreateName();
        (bool isValid, int yearInt) = ValidatePerson(name, CreateYear());

        if (isValid)
        {
            await _nobelData.Update(id, 
                new NobelModel 
                {
                    Name = name!,
                    Year = yearInt
                });

            Console.WriteLine($"{chosenPerons.Name} is updated");
            return;
        }
        Console.WriteLine("Fail Try Again");
    }

    public async Task Delete()
    {
        await Read();
        Console.WriteLine("What person do u want to delete? Enter Id");
        string? idString = Console.ReadLine();
        bool isValidId = int.TryParse(idString, out int id);

        if (isValidId)
        {
            try
            {
                await _nobelData.DeleteById(id);
                Console.WriteLine("User was deleted");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Fail Try Again");

    }


    private string? CreateName()
    {
        Console.WriteLine("Enter the name:");
        return Console.ReadLine();
    }

    private string? CreateYear()
    {
        Console.WriteLine("Enter the year the person took the prize");
        return Console.ReadLine();
    }

    private (bool, int) ValidatePerson(string? name, string? yearString)
    {
        // om de har lagt in ett numer och det är mella 1900 till nu är isValidYear true annars blir det false
        bool isValidYear = int.TryParse(yearString, out int year) && year >= 1900 && year <= DateTime.Now.Year;

        bool isValidName = !string.IsNullOrEmpty(name) && name.Length >= 2;

        return (isValidYear && isValidName, year);
    }


}
