using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeonTicaret.Model
{
    public class Sales : Base
    {
        public string CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
        public double Cost { get; set; }
        public bool IsBasket { get; set; }
        public int CargoId { get; set; }
        public int OrderStatusId { get; set; }
        public int CargoTrackNo { get; set; }
    }
}
