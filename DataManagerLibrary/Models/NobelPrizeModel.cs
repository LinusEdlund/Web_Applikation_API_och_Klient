
using System.ComponentModel.DataAnnotations;

namespace DataManagerLibrary.Models;
public class NobelPrizeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Range(1900, 2030, ErrorMessage = "Please put in a year where the person claimd the prize, not how old he is")]
    public int Year { get; set; }
}
