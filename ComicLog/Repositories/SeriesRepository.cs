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

        public List<Series> GetAllByUser(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from series where UserId = @id";
                    DbUtils.AddParameter(cmd, "@id", id);
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

        public void Add(Series series)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Insert Into Series ([Name], Comic,
                    UserId, IsManga, IsCompleted)
                    Output Inserted.Id
                    Values(@name, @comic, @userId, @isManga, @isCompleted)";
                    DbUtils.AddParameter(cmd, "@name", series.Name);
                    DbUtils.AddParameter(cmd, "@comic", series.Comic);
                    DbUtils.AddParameter(cmd, "@userId", series.UserId);
                    DbUtils.AddParameter(cmd, "@isManga", series.IsManga);
                    DbUtils.AddParameter(cmd, "@isCompleted", series.IsCompleted);

                    series.Id = (int)cmd.ExecuteScalar();

                }
            }
        }
    }
}
