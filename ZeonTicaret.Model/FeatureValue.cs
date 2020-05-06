using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZeonTicaret.Model
{
    public class FeatureValue : Base
    {
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int? FeatureTypeId { get; set; }
    }
}
