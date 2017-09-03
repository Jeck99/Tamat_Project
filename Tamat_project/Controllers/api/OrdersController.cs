using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamat_project.Models;

namespace Tamat_project.Controllers.api
{
    public class OrdersController : ApiController
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        // simple validation
        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }

        [HttpPost]//יצירת הזמנות
        public IHttpActionResult CreateBlog(string User_Name, long Order_Price,string Order_Date)
        {
            if (!validationIsOk(User_Name) || !validationIsOk(Order_Price.ToString())|| !validationIsOk(Order_Date)) { return BadRequest(); }
            Orders Orders = new Orders { User_Name = User_Name, Order_Price = Order_Price , Order_Date = Order_Date };
            m_db.Orders.Add(Orders);
            m_db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = Orders.Id }, Orders);
        }
        [HttpGet]
        public IEnumerable<Orders> Get_Orders()
        {
            return m_db.Orders;
        }

        [HttpGet]//הצגת הזמנות
        public IHttpActionResult Get_Orders(long id)
        {
            Orders Orders_tem = m_db.Orders.Find(id);
            if (Orders_tem == null)
            {
                return NotFound();
            }
            return Ok(Orders_tem);
        }

        [HttpPut]//עריכה
        public IHttpActionResult Update_Order(long id, Orders Orders)
        {
            if (!validationIsOk(Orders.User_Name) || !validationIsOk(Orders.Order_Price.ToString())) { return BadRequest(); }
            Orders OrdersObj = m_db.Orders.Find(id);
            if (OrdersObj == null) { return NotFound(); }
            OrdersObj.User_Name = Orders.User_Name;
            OrdersObj.Order_Price = Orders.Order_Price;
            OrdersObj.Order_Date = Orders.Order_Date;
            m_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]//מחיקה
        public IHttpActionResult DeleteOrder(long id)
        {
            Orders OrdersObj = m_db.Orders.Find(id);
            if (OrdersObj == null)
            {
                return NotFound();
            }
            m_db.Orders.Remove(OrdersObj);
            m_db.SaveChanges();
            return Ok(OrdersObj);
        }
    }
}
