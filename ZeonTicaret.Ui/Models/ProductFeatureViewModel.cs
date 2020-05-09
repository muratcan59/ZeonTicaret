using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeonTicaret.Ui.Models
{
    public class ProductFeatureViewModel
    {
        public int? ProductId { get; set; }
        public int? FeatureTypeId { get; set; }
        public int? FeatureValueId { get; set; }
    }
}