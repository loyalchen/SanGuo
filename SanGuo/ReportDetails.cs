using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SanGuo.Model;
using System.Collections;
using System.Collections.Generic;

namespace SanGuo
{
    public partial class ReportDetails : Form
    {
        public ReportDetails()
        {
            InitializeComponent();
        }

        private IEnumerable<Member> GetDataSource()
        {
            List<Member> list = new List<Member>();

            for (int i = 0; i < 21; i++)
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
                        Door = "Door" + 1
                    };
                }
                else
                {
                    member.MyAddress = new Address()
                    {
                        Id = i + 1,
                        Street = "Street" + 1,
                        Door = "Door" + 1
                    };
                }
                member.Level = "Level" + (i + 1);
                member.Office = "IT";
                list.Add(member);
            }
            for (int i = 21; i < 31; i++)
            {
                Member member = new Member();
                member.Id = i + 1;
                member.Name = null;

                member.MyAddress = new Address()
                {
                    Id = i + 1,
                    Street = "Street" + 3,
                    Door = "Door" + 3
                };

                member.Level = "Level" + (i + 1);
                member.Office = "Document";
                list.Add(member);
            }

            return list;
        }

        private void ReportDetails_Shown(object sender, EventArgs e)
        {
            cmbGVReport.DataSource = GetDataSource();
        }
    }
}
