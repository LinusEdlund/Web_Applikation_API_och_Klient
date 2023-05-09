
namespace DataManagerLibrary.Models;
public class NobelPrizeModel
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public string Citation { get; set; }
    public string Country { get; set; }
    public string Institution { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }

    public NobelPrizeModel(int id, int year, string name, string citation, string country, string institution, string gender, int age)
    {
        Id = id;
        Year = year;
        Name = name;
        Citation = citation;
        Country = country;
        Institution = institution;
        Gender = gender;
        Age = age;
    }
}
