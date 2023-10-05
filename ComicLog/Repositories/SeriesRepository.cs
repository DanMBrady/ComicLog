using ComicLog.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ComicLog.Utils;


namespace ComicLog.Repositories
{
    public class SeriesRepository : BaseRepository, ISeriesRepository
    {
        public SeriesRepository(IConfiguration configuration) : base(configuration) { }

        public List<Series> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from series";
                    var reader = cmd.ExecuteReader();
                    var s = new List<Series>();
                    while (reader.Read())
                    {
                        var series = new Series()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Comic = DbUtils.GetInt(reader, "Comic"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            IsManga = reader.GetBoolean(reader.GetOrdinal("IsManga")),
                            IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                        };
                        s.Add(series);

                    }
                    return s;
                }
            }
        }
    }
}
