using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeonTicaret.Model
{
    public class SalesDetail : Base
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
