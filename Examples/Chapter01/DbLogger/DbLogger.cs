using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Examples.Chapter01.DbLogger
{
    using static ConnectionHelper;

    public class DbLogger
    {
        string connString;

        public void Log(LogMessage message) 
            => Connect(
                connString, 
                c => c.Execute("sp_create_log", message, commandType: CommandType.StoredProcedure)
            );

        public IEnumerable<LogMessage> GetLogs(DateTime since)
            => Connect(
                connString, 
                c => c.Query<LogMessage>(@"SELECT * FROM [Logs] WHERE [TIMESTAMP] > @since", new { since = since })
           );
    }
}
