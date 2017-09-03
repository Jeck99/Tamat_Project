using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamat_project.Models
{
    public class Product
    {
        public long Id { get; set; }//primary key
        public string Product_Name { get; set; }
        public long Customer_Price { get; set; }
        public long Market_Price { get; set; }
    }
}