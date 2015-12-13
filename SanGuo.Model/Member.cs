using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanGuo.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public Address MyAddress { get; set; }
        public string Office { get; set; }
    }
}
