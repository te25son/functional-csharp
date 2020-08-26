using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Examples.Chapter01.DbLogger
{
    public class DbLogger
    {
        string connString;

        public void Log(LogMessage message)
        {
            using (var conn = new SqlConnection(connString))
            {
                int affectedRows = conn.Execute("sp_create_log", message, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<LogMessage> GetLogs(DateTime since)
        {
            var sqlGetLogs = "SELECT * FROM [Logs] WHERE [TIMESTAMP] > @since";
            using (var conn = new SqlConnection(connString))
            {
                return conn.Query<LogMessage>(sqlGetLogs, new { since = since });
            }
        }
    }
}
