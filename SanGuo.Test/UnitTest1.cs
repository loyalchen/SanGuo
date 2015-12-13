using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanGuo.DAL;

namespace SanGuo.Test
{
    [TestClass]
    public class UnitTest1
    {
        public void TestMethod1()
        {
            TestDAL.OpenWithoutPooling();
            Console.WriteLine("Waiting for 10s");
            System.Threading.Thread.Sleep(10 * 1000);
            TestDAL.OpenWithoutPooling();
            Console.WriteLine("Waiting for 600s");
            System.Threading.Thread.Sleep(600 * 1000);
            TestDAL.OpenWithoutPooling();
        }
    }
}
