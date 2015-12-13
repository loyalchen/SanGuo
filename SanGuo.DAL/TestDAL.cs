using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace SanGuo.DAL
{
    public class TestDAL
    {
        static int count = 1000000;
        static string connectionString = @"Data Source=LENOVO-PC\CHENYI; Initial Catalog=Student; Integrated Security=SSPI;";
        public static void OpenWithoutPooling()
        {
            string connectionString =
                @"Data Source=LENOVO-PC\CHENYI; Initial Catalog=Student; Integrated Security=SSPI;";

            Stopwatch sw = new Stopwatch();

            sw.Start();
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();
            }

            sw.Stop();
            Console.WriteLine("Without Pooling, first connection elapsed {0} ms", sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();

            for (int i = 0; i < 100; i++)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }
            }

            sw.Stop();
            Console.WriteLine("Without Pooling, average connection elapsed {0} ms", sw.ElapsedMilliseconds / 100);
        }


        /// <summary>
        /// 普通调用存储过程插入数据
        /// </summary>
        /// <returns></returns>
        public static long ComonInsert()
        {
            Stopwatch sw = new Stopwatch();
            SqlConnection connection = new SqlConnection(connectionString);
            string passwortKey;
            connection.Open();

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                passwortKey = Guid.NewGuid().ToString();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@passport", passwortKey);
                //SqlParameter parameter = new SqlParameter("@passport", passwortKey);
                connection.Execute("up_createPassport", parameter, commandType: CommandType.StoredProcedure);
            }
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 使用SqlBulkCopy批量存储数据
        /// </summary>
        /// <returns></returns>
        public static long SqlBulkCopyInsert()
        {
            Stopwatch sw = new Stopwatch();

            DataTable dt = GetTableSchema();
            string passportKey;

            for (int i = 0; i < count; i++)
            {
                passportKey = Guid.NewGuid().ToString();
                DataRow dataRow = dt.NewRow();
                dataRow[0] = passportKey;
                dt.Rows.Add(dataRow);
            }

            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connectionString);
            sqlBulkCopy.DestinationTableName = "Passport";
            sqlBulkCopy.BatchSize = dt.Rows.Count;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sw.Start();
            if (dt != null && dt.Rows.Count != 0)
            {
                sqlBulkCopy.WriteToServer(dt);
            }

            sqlBulkCopy.Close();
            sqlConnection.Close();

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 采取表值法插入数据
        /// </summary>
        /// <returns></returns>
        public static long TVPInsert()
        {
            Stopwatch sw = new Stopwatch();

            SqlConnection connection = new SqlConnection(connectionString);
            DataTable dt = GetTableSchema();
            string passportKey;

            for (int i = 0; i < count; i++)
            {
                passportKey = Guid.NewGuid().ToString();
                DataRow dtRow = dt.NewRow();
                dtRow[0] = passportKey;
                dt.Rows.Add(dtRow);
            }

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@TVP", dt, DbType.Object);
            connection.Open();
            sw.Start();
            connection.Execute("up_create_passportWithTVP", parameter, commandType: CommandType.StoredProcedure);

            connection.Close();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 定义一个DataTable的列
        /// </summary>
        /// <returns></returns>
        private static DataTable GetTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("PassportKey") });

            return dt;
        }
    }
}
