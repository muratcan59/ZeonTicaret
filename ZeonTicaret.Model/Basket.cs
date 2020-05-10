﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeonTicaret.Model
{
    public class Basket : Base
    {
        public int? ProductId { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }   
    }
}
