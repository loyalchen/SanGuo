using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanGuo.Model
{
    public class Option<T>
    {
        public string GroupName { get; set; }
        public T Value { get; set; }
    }
}
