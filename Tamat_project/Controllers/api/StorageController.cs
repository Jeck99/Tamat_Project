using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamat_project.Models;

namespace Tamat_project.Controllers.api
{
    public class StorageController : ApiController
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        // simple validation
        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }

        [HttpPost]//יצירת מידע
        public IHttpActionResult CreateBlog(string Product_Name, long Amount)
        {
            if (!validationIsOk(Product_Name)|| !validationIsOk( Amount.ToString())) { return BadRequest(); }
            Storage Storage = new Storage { Product_Name = Product_Name, Amount = Amount };
            m_db.Storage.Add(Storage);
            m_db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = Storage.Id }, Storage);
        }

        [HttpGet]//
        public IEnumerable<Storage> Get_Storage()
        {
            return m_db.Storage;
        }

        [HttpGet]//הצגת מידע
        public IHttpActionResult Get_Storage(long id)
        {
            Storage Storage_tem = m_db.Storage.Find(id);
            if (Storage_tem == null)
            {
                return NotFound();
            }
            return Ok(Storage_tem);
        }

        [HttpPut]//עריכת מידע
        public IHttpActionResult Update_Instructor(long id, Storage Storage)
        {
            if (!validationIsOk(Storage.Product_Name) || !validationIsOk(Storage.Amount.ToString())) { return BadRequest(); }
            Storage StorageObj = m_db.Storage.Find(id);
            if (StorageObj == null) { return NotFound(); }
            StorageObj.Product_Name = Storage.Product_Name;
            StorageObj.Amount = Storage.Amount;
            m_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]//מחיקת מידע
        public IHttpActionResult DeleteStorage(long id)
        {
            Storage StorageObj = m_db.Storage.Find(id);
            if (StorageObj == null)
            {
                return NotFound();
            }
            m_db.Storage.Remove(StorageObj);
            m_db.SaveChanges();
            return Ok(StorageObj);
        }
    }
}
