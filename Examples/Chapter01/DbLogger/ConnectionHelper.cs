using System;
using System.Data;
using System.Data.SqlClient;

namespace Examples.Chapter01.DbLogger
{
    public static class ConnectionHelper
    {
        public static R Connect<R>(string connString, Func<IDbConnection, R> func)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                return func(conn);
            }
        }
    }
}
