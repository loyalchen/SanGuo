using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanGuo.Model;
using SanGuo.DAL;

namespace SanGuo.BLL
{
    public class StudentBLL
    {
        public IEnumerable<Student> GetStudent()
        {
            StudentDAL dal = new StudentDAL();
            return dal.GetList();
        }
    }
}
