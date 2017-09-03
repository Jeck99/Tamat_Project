using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamat_project.Models
{
    public class Users
    {
        public long Id { get; set; }//primary key
        public string User_Name { get; set; }
        public string Address { get; set; }
        public string Business { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Registration_Date { get; set; }
        public string Password { get; set; }

    }
}