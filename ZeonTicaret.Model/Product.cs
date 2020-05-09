using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZeonTicaret.Model
{
    public class Product : Base
    {
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public DateTime LastUseDate { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
