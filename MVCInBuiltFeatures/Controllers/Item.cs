using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCInBuiltFeatures.Models;


namespace MVCInBuiltFeatures.Controllers
{
    public class Item
    {
        private Medicine med = new Medicine();

        public Medicine Med
        {
            get { return med; }
            set { med = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item() { }

        public Item(Medicine med, int quantity) 
        {
            this.med = med;
            this.quantity = quantity;
        }
    }
}