using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SanGuo.Model;

namespace SanGuo.DAL
{
    public class StudentDAL
    {
        public IEnumerable<Student> GetStudent(int Id)
        {
            string sqlConnection = @"Data Source=LENOVO-PC\CHENYI; Initial Catalog=Student; Integrated Security=SSPI";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                DynamicParameters param = new DynamicParameters();
                IEnumerable<Student> list = new List<Student>();

                param.Add("@Id", Id);
                connection.Open();

                list = connection.Query<Student>("up_getStudent", param, commandType: CommandType.StoredProcedure);

                connection.Close();

                return list;
            }
        }

        public IEnumerable<Student> GetList()
        {
            using (SqlConnection connection = new SqlConnection(SqlBase.connectionString))
            {
                IEnumerable<Student> list;
                connection.Open();
                list = connection.Query<Student>("select * from Student", commandType: CommandType.Text);
                connection.Close();

                return list;
            }
        }
    }
}
