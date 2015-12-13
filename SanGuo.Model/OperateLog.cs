using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanGuo.Model
{
    public class OperateLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OpDateTime { get; set; }
        public string Description { get; set; }
        public string JsonString { get; set; }
    }
}
