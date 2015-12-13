using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanGuo.DAL;

namespace SanGuo.Test
{
    [TestClass]
    public class InsetSqlCommpare
    {
        public void TestMethod1()
        {
            //long commonInsert = TestDAL.ComonInsert();
            long tvpInsert = TestDAL.TVPInsert();
            long sqlBulkCopy = TestDAL.SqlBulkCopyInsert();

            //Console.WriteLine("普通调用存储过程插入:{0}ms", commonInsert);
            Console.WriteLine("采取表值法插入:{0}ms", tvpInsert);
            Console.WriteLine("采取SqlBulkCopy方法:{0}ms", sqlBulkCopy);
        }
    }
}
