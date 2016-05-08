using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCInBuiltFeatures.Models;


namespace MVCInBuiltFeatures.Controllers
{
    public class Item
    {
        
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item() { }

        
    }
}