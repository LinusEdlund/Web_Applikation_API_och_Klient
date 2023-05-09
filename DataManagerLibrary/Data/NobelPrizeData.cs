using DataManagerLibrary.DbAccess;
using DataManagerLibrary.Models;

namespace DataManagerLibrary.Data;
public class NobelPrizeData : INobelPrizeData
{
    private readonly IDataAccess _db;

    public NobelPrizeData(IDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<NobelPrizeModel>> GetAll() =>
        _db.LoadDataAsync<NobelPrizeModel, dynamic>("nobel.spNoble_GetAll", new { });
}
