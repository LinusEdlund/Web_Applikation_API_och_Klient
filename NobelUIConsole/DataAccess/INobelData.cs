using NobelUIConsole.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelUIConsole.DataAccess;
public interface INobelData
{
    [Get("/api/NobelPrize")]
    Task<List<NobelModel>> GetAll();

    [Get("/api/NobelPrize/{id}")]
    Task<NobelModel> GetById(int id);

    [Post("/api/NobelPrize")]
    Task Create([Body] NobelModel model);

    [Put("/api/NobelPrize")]
    Task Update(int id, [Body] NobelModel model);

    [Delete("/api/NobelPrize")]
    Task DeleteById(int id);
}
