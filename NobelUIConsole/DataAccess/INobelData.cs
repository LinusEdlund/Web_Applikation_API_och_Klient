using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILibrary.Models;

namespace UILibrary.DataAccess;
public interface INobelData
{
    [Get("/api/NobelPrize")]
    Task<List<NobelModel>> GetAll();
}
