using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamat_project.Models;

namespace Tamat_project.Controllers.api
{
    public class ProductsController : ApiController
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        // simple validation
        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }

        [HttpPost]//יצירת 
        public IHttpActionResult CreateProduct(string Product_Name, long Customer_Price, long Market_Price)
        {
            if (!validationIsOk(Product_Name) || !validationIsOk(Customer_Price.ToString()) || !validationIsOk(Market_Price.ToString())) { return BadRequest(); }
            Product Product = new Product { Product_Name = Product_Name, Customer_Price = Customer_Price, Market_Price = Market_Price };
            m_db.Product.Add(Product);
            m_db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = Product.Id }, Product);
        }
        [HttpGet]
        public IEnumerable<Product> Get_Product()
        {
            return m_db.Product;
        }

        [HttpGet]//הצגת 
        public IHttpActionResult Get_Product(long id)
        {
            Product Product_tem = m_db.Product.Find(id);
            if (Product_tem == null)
            {
                return NotFound();
            }
            return Ok(Product_tem);
        }

        [HttpPut]//עריכה
        public IHttpActionResult Update_Product(long id, Product Product)
        {
            if (!validationIsOk(Product.Product_Name) || !validationIsOk(Product.Customer_Price.ToString())|| !validationIsOk(Product.Market_Price.ToString())) { return BadRequest(); }
            Product ProductObj = m_db.Product.Find(id);
            if (ProductObj == null) { return NotFound(); }
            ProductObj.Product_Name = Product.Product_Name;
            ProductObj.Customer_Price = Product.Customer_Price;
            ProductObj.Market_Price = Product.Market_Price;
            m_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]//מחיקה
        public IHttpActionResult DeleteProduct(long id)
        {
            Product ProductObj = m_db.Product.Find(id);
            if (ProductObj == null)
            {
                return NotFound();
            }
            m_db.Product.Remove(ProductObj);
            m_db.SaveChanges();
            return Ok(ProductObj);
        }
    }
}
