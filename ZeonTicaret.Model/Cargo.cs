using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeonTicaret.Model
{
    public class Cargo : Base
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string WebSite { get; set; }
        public string EMail { get; set; }
    }
}
