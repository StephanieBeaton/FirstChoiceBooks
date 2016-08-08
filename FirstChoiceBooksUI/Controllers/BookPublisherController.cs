using FirstChoiceBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstChoiceBooksUI.Controllers
{
    public class BookPublisherController : Controller
    {
        // GET: BookPublisher
        public ActionResult Index()
        {
            // hard coded customer -- needs fixing
            var unpaidOrders = BookPrintingCompany.GetCustomerUnpaidOrdersByEmailAddress("jane@test.com");
            return View(unpaidOrders);
        }

        // method does not need parameter 
        // ... because we are creating a new unpaid order
        [HttpGet]
        public ActionResult Create()
        {
            // hard coded customer - needs fixing
            // var customer = BookPrintingCompany.GetCustomerByCustomerEmail("jane@test.com");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            // hard coded customer -- needs fixing
            var customer = BookPrintingCompany.GetCustomerByCustomerEmail("jane@test.com");

            BookPrintingCompany.CreateCustomerOrder(customer,
                                                    order.Description,
                                                    order.ReceivedDate,
                                                    order.ShippedToAddress,
                                                    order.TotalPrice);

            return RedirectToAction("Index");
        }

}
}