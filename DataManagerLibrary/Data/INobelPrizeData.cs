using DataManagerLibrary.Models;

namespace DataManagerLibrary.Data;

public interface INobelPrizeData
{
    Task DeleteById(int id);
    Task<IEnumerable<NobelPrizeModel>> GetAll();
    Task<NobelPrizeModel?> GetById(int id);
    Task Insert(NobelPrizeModel nobel);
    Task Update(NobelPrizeModel nobel);
}