using System;
using System.Data;
using System.Data.SqlClient;
using static Functional.ActionExtensions;

namespace Examples.Chapter01.DbLogger
{
    public static class ConnectionHelper
    {
        public static R Connect<R>(string connString, Func<IDbConnection, R> func)
            => Using(
                new SqlConnection(connString), 
                conn => { conn.Open(); return func(conn); }
            );
    }
}
