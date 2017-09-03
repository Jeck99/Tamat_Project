using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamat_project.Models;

namespace Tamat_project.Controllers.api
{
    public class UsersController : ApiController
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        // simple validation
        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }

        [HttpPost]//יצירת 
        public IHttpActionResult CreateUsers(string Users_Name, string Address, string Business, string Email, string Role, string Registration_Date, string Password)
        {
            if (!validationIsOk(Users_Name) || !validationIsOk(Address) || !validationIsOk(Business) || !validationIsOk(Email) || !validationIsOk(Registration_Date) || !validationIsOk(Password)) { return BadRequest(); }
            Users User_obj = new Users { User_Name = Users_Name, Address = Address, Business = Business, Email= Email, Role= Role, Registration_Date= Registration_Date, Password = Password };
            m_db.User.Add(User_obj);
            m_db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = User_obj.Id }, User_obj);
        }
        [HttpGet]
        public IEnumerable<Users> Get_Users()
        {
            return m_db.User;
        }

        [HttpGet]//הצגת 
        public IHttpActionResult Get_Users(long id)
        {
            Users Users_tem = m_db.User.Find(id);
            if (Users_tem == null)
            {
                return NotFound();
            }
            return Ok(Users_tem);
        }

        [HttpPut]//עריכה
        public IHttpActionResult Update_Users(long id, Users Users)
        {
            if (!validationIsOk(Users.User_Name) || !validationIsOk(Users.Address) || !validationIsOk(Users.Business) || !validationIsOk(Users.Email) || !validationIsOk(Users.Registration_Date) || !validationIsOk(Users.Password)) { return BadRequest(); }
            Users UsersObj = m_db.User.Find(id);
            if (UsersObj == null) { return NotFound(); }
            UsersObj.User_Name = Users.User_Name;
            UsersObj.Address = Users.Address;
            UsersObj.Business = Users.Business;
            UsersObj.Email = Users.Email;
            UsersObj.Registration_Date = Users.Registration_Date;
            UsersObj.Password = Users.Password;
            m_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]//מחיקה
        public IHttpActionResult DeleteUsers(long id)
        {
            Users UsersObj = m_db.User.Find(id);
            if (UsersObj == null)
            {
                return NotFound();
            }
            m_db.User.Remove(UsersObj);
            m_db.SaveChanges();
            return Ok(UsersObj);
        }
    }
}
