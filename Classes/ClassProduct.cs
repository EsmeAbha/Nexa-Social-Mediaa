﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace media.Classes
{
    internal class ClassProduct
    {
        private string productname;
        private string productDescription;
        private double productPrice;
        private Image[] productImages;
        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
        public string ProductDescription
        {
            get { return productDescription; }
            set
            {
                productDescription = value;
            }
        }
        public double ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }
        public Image[] ProductImages
        {
            get { return productImages; }
            set
            {
                productImages = value;
            }
        }
        public ClassProduct(string productName, string productDescription, double productPrice, Image[] productImages)
        {
            this.ProductName= productName;
            this.ProductDescription= productDescription;
            this.ProductPrice= productPrice;
            this.ProductImages= productImages;
        }
    }
}
