using ComicLog.Models;
using System.Collections.Generic;

namespace ComicLog.Repositories
{
    public interface ISeriesRepository
    {
        List<Series> GetAll();

        List<Series> GetAllByUser(int id);

        void Add(Series series);
    }
}