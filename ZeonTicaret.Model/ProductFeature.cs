using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeonTicaret.Model
{
    public class ProductFeature : Base
    {
        public int? ProductId { get; set; }
        public int? FeatureTypeId { get; set; }
        public int? FeatureValueId { get; set; }
    }
}
