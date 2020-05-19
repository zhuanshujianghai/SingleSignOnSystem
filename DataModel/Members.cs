using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel
{
    public class Members
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Remark { get; set; }
    }
}
