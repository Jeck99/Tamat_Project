using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamat_project.Models
{
    public class Orders
    {
        public long Id { get; set; }//primary key
        public string User_Name { get; set; }
        public long Order_Price { get; set; }
        public string Order_Date  { get; set; }
    }
}