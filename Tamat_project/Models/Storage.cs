using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamat_project.Models
{
    public class Storage
    {
        public long Id { get; set; }//primary key
        public string Product_Name { get; set; }
        public long Amount { get; set; }
    }
}