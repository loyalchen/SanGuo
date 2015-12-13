using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;
using System.Collections;
using SanGuo.Model;

namespace SanGuo
{
    public partial class DynamicLinq : Form
    {
        public DynamicLinq()
        {
            InitializeComponent();
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            DynamicLinqQueryTest dl = new DynamicLinqQueryTest();
            DataTable dt = new DataTable();
            DataColumn[] dc = new DataColumn[] { new DataColumn("Id"), new DataColumn("Name") };
            dt.Columns.Add("Key");
            dt.Columns.Add("Level");
            dt.Columns.AddRange(dc);
            IEnumerable member = dl.Test();
            foreach (dynamic item in member)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.Id;
                dr["Level"] = item.Level;
                dr["Key"] = item.Key;
                dr["Name"] = item.Name;
                dt.Rows.Add(dr);
            }
            gvMain.DataSource = dt;
            
        }
    }

    public class DynamicLinqQueryTest
    {
        public List<Member> _list = new List<Member>();

        public void Initilize()
        {
            for (int i = 0; i < 20; i++)
            {
                Member member = new Member();
                member.Id = i + 1;
                member.Name = null;
                if (i % 2 == 0)
                {
                    member.MyAddress = new Address()
                    {
                        Id = i + 1,
                        Street = "Street" + 2,
                        Door = "Door" + (i + 1)
                    };
                }
                else
                {
                    member.MyAddress = new Address()
                    {
                        Id = i + 1,
                        Street = "Street" + 1,
                        Door = "Door" + (i + 1)
                    };
                }
                member.Level = "Level" + (i + 1);
                _list.Add(member);
            }
        }

        public IEnumerable Test()
        {
            Initilize();

            var members = _list.GroupBy("it.MyAddress.Street", "it").Select("new(Key,Count(Id!=0) as Id,Count(Name!=NULL) as Name, Count(Level!=null) as Level )");
            return members;
        }


    }
}
