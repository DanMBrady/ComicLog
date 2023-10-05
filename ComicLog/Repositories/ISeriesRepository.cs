using ComicLog.Models;
using System.Collections.Generic;

namespace ComicLog.Repositories
{
    public interface ISeriesRepository
    {
        List<Series> GetAll();
    }
}