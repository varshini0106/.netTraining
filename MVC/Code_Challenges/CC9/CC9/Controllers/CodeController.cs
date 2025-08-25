//1.Develop an MVC application 

// - Connect to the backend database Northwind using database first approach.

// - Create a controller called CodeController.(Empty Controller only)

// -Create 2 action methods
//  1. First action method should return all customers residing in Germany

//  2. Second action method should return customer details with an orderId==10248

//Create required Views to display the output ( no scaffolding)

//Hint: Use Linq to construct the query 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CC9.Models;

namespace CC9.Controllers
{
    public class CodeController : Controller
    {
        NorthWindEntities db = new NorthWindEntities();

        // Action 1: Customers in Germany
        public ActionResult CustomersInGermany()
        {
            var germany_customers = db.Customers
                                    .Where(c => c.Country == "Germany")
                                    .ToList();
            return View(germany_customers);
        }

        // Action 2: Customer details for OrderID == 10248
        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();
            return View(customer);
        }
    }
}