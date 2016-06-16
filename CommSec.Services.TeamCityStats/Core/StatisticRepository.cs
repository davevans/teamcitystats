using System.Data;
using System.Data.SqlClient;
using CommSec.Services.TeamCityStats.Models;

namespace CommSec.Services.TeamCityStats.Core
{
    public class StatisticRepository
    {
        private readonly Configuration _configuration;
        
        public StatisticRepository(Configuration configuration)
        {
            _configuration = configuration;
        }

        public long AddStatistic(Statistic statistic)
        {
            using (var sqlConnection = new SqlConnection(_configuration.Database))
            {
                using (var sqlCommand = new SqlCommand(@"StatisticInsert", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(@"Key", statistic.Key);
                    sqlCommand.Parameters.AddWithValue(@"Value", statistic.Value);
                    sqlCommand.Parameters.AddWithValue(@"BuildId", statistic.BuildId);
                    sqlCommand.Parameters.AddWithValue(@"BuildNumber", statistic.BuildNumber);

                    var outParam = new SqlParameter("Id", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    sqlCommand.Parameters.Add(outParam);
                    sqlCommand.ExecuteNonQuery();

                    return (long) outParam.Value;
                }
            }
        }
    }
}
