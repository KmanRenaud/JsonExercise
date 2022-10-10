﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise
{
    internal class Products
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public bool OnSale { get; set; }
        public int StockLevel { get; set; }

    }
}