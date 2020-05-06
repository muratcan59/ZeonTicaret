using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeonTicaret.Model
{
    public class Photo : Base
    {
        public string Path { get; set; }
        public int OrderNo { get; set; }
        public int? ProductId { get; set; }
    }
}
