﻿using DataManagerLibrary.DbAccess;
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

    public async Task<NobelPrizeModel?> GetById(int id) 
    {
        var nobelPrizes = await _db.LoadDataAsync<NobelPrizeModel, dynamic>("nobel.spNobel_GetById", new { p_Id = id });

        return nobelPrizes.FirstOrDefault();
    }

    public Task Create(NobelPrizeModel nobel) =>
        _db.SaveDataAsync<dynamic>("nobel.spNobel_Insert", new { nobel.Name, nobel.Year });

    public Task Delete(int id) =>
        _db.SaveDataAsync("nobel.spNobel_Delete", new { p_Id = id });

    public Task Update(NobelPrizeModel nobel) =>
        _db.SaveDataAsync("nobel.spNobel_Update", new { p_Id = nobel.Id, nobel.Name, nobel.Year });
        
}
