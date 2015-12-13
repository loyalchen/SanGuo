using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using SanGuo.BLL;
using System.Data;
using SanGuo.Model;

namespace SanGuo.Test
{
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// 常规调用以及反射调用方法比较
        /// </summary>
        public void TestMethod1()
        {
            int count = 1000000;
            Stopwatch sw = new Stopwatch();
            UnitTest2 program = new UnitTest2();
            Object[] obj = { new Object(), new Object(), new Object() };

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                Call(obj[0], obj[1], obj[2]);
            }
            sw.Stop();
            Console.WriteLine("常规调用时间:{0}", sw.ElapsedMilliseconds);

            MethodInfo mInfo = typeof(UnitTest2).GetMethod("Call");

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                mInfo.Invoke(program, obj);
            }
            sw.Stop();

            Console.WriteLine("反射调用的时间：{0}", sw.ElapsedMilliseconds);
        }

        public void Call(object obj1, object obj2, object obj3)
        {

        }

        public void Test()
        {
            var obj = new { Guid.Empty, myTitle = "匿名类型", myOtherParam = new int[] { 1, 2, 3, 4 } };
            Console.WriteLine(obj.Empty);//另一个对象的属性名字，被原封不动的拷贝到匿名对象中来了。
            Console.WriteLine(obj.myTitle);
        }

        public void Test1()
        {
            List<int> arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            arr.ForEach(new Action<int>(delegate(int a) { Console.WriteLine(a); }));
            arr.ForEach(new Action<int>(a => Console.WriteLine(a)));
        }

        public void Test2()
        {
            List<int> lis = new List<int>() { 1, 2, 3, 4 };
            lis.Select1();
        }

        [TestMethod]
        public void Testasd()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Rows.Add(1);
            ReportGenerator root = new ReportGenerator(dt, new Option<string>() { GroupName = "RefId",Value="RefId" },"Father");
            var son = root.AddSubReport(new Option<string>() { GroupName = "Son", Value = "Son" }, "Son");
            var grandson = root.AddSubReport(new Option<string>() { GroupName = "Grandson", Value = "Grandson" }, "Grandson");
            root.GenerateReport();
            son.DropReport();
        }
    }

    public static class ExpandMehod
    {
        public static void PrintSomething(this String a)
        {
            Console.WriteLine(a);
        }

        public static void Select1(this List<int> a)
        {
            foreach (var i in a)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }

}
