using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SanGuo.BLL;
using SanGuo.Model;
using SanGuo.Tools;
using Newtonsoft.Json;

namespace SanGuo
{
    public partial class Form1 : Form
    {
        List<OperateLog> list2 = new List<OperateLog>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            BindDataToGridView();
        }

        private void BindDataToGridView()
        {
            //List<Student> list = new List<Student>();
            //list = GetDataSource().Where(a => { return a.Age == 24; }).ToList();
            //gvMain.DataSource = list;

            //IEnumerable<Student> list;
            //List<Student> list2;
            //list = GetDataSource().Where(a => a.Age == 24);
            //list2 = list.ToList();

            //gvMain.DataSource = GetDataSource().Where(a => a.Age == 24).ToList();

            List<Student> list = new List<Student>();
            //List<Student> list2;

            list.Add(new Student() { StuId = 2008011217, StuName = "陈义", Age = 24 });
            list.Add(new Student() { StuId = 2008011218, StuName = "陈林", Age = 26 });

            string json = JsonHelper.SerializeObject(list);

            IEnumerable<Student> studentInfo = JsonHelper.DeserializeJsonToCollection<Student>(json);


            gvMain.DataSource = studentInfo;

            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "Name";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["Name"] = "陈义";
            dt.Rows.Add(dr);

            Option<string> o =  new Option<string>();
            ReportGenerator r = new ReportGenerator(dt, o);

            var r2 = r.AddSubReport(o);
            r2.ChangePreReport(r,dt);

            var r3 = r.AddSubReport(o);

            r2.DropReport();
            r2.DropReport();
            //list2 = list.Where(c => c.Age == 24).ToList();

        }

        private IEnumerable<Student> GetDataSource()
        {
            StudentBLL bll = new StudentBLL();
            return bll.GetStudent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void InitControl()
        {
            foreach (var item in list2)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Description;
                treeview1.Nodes.Add(node);
            }
        }

        private void InitData()
        {
            List<Student> list = new List<Student>();

            List<Student> list3 = new List<Student>();

            list.Add(new Student() { StuId = 2008011217, StuName = "陈义", Age = 24 });

            list3.Add(new Student(){ StuId = 2008011218, StuName = "陈琳", Age = 26 });

            string json = JsonHelper.SerializeObject(list);
            string json2 = JsonHelper.SerializeObject(list3);

            OperateLog logmodel = new OperateLog() { Id = 1, UserName = "陈义", OpDateTime = DateTime.Now, Description = "Update", JsonString = json };
            StringBuilder str = new StringBuilder();
            str.Append(logmodel.UserName);
            str.Append(":");
            str.Append(logmodel.OpDateTime.ToString());
            str.Append(":");
            str.Append(logmodel.Description);
            list2.Add(new OperateLog() { Id = logmodel.Id, Description = str.ToString(), JsonString = logmodel.JsonString });
            list2.Add(new OperateLog() { Id = logmodel.Id, Description = str.ToString(), JsonString = json2 });
        }

        private void treeview1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeview1.SelectedNode != null)
            {
                TreeNode node = new TreeNode();
                int i;
                i = e.Node.Index;
                IEnumerable<Student> studentInfo = JsonHelper.DeserializeJsonToCollection<Student>(list2[i].JsonString);

                gvMain.DataSource = studentInfo;
            }
        }
    }
}
