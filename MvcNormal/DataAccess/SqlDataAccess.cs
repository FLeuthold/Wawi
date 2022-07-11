using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.Extensions.Configuration;

namespace MvcNormal.Data
{
    public static class SqlDataAccess
    {
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["MockDB"].ToString();

        //private readonly IConfiguration _conf;



        public static List<T> LoadData<T, U>(
            string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connstr))
            {
                var res = conn.Query<T>(sql, parameters);
                return res.ToList();
            }

        }

        public static List<T> LoadData<T>(
            string sql)
        {
            using (IDbConnection conn = new SqlConnection(connstr))
            {
                var res = conn.Query<T>(sql);
                return res.ToList();
            }

        }

        public static void SaveData<T>(
            string sql,
            T parameters,
            string connectionID = "Default")
        {
            using (IDbConnection conn = new SqlConnection(connstr))
            {
                conn.Execute(sql, parameters,
                    commandType: CommandType.Text);
            }
        }


    }
}