using DataManagerLibrary.Models;

namespace DataManagerLibrary.Data;

public interface INobelPrizeData
{
    Task<IEnumerable<NobelPrizeModel>> GetAll();
}