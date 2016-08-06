using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChoiceBooks
{
    public static class BookPrintingCompany
    {
        #region Properties
        public static string Name { get; set; }

        public static string Address { get; set; }

        public static string Owner { get; set; }
        #endregion

        #region Methods
        public static Customer CreateCustomer(string name, string emailAddress)
        {
            // if a customer already exists with this emailAddress 
            // ... return null customer
            var db = new FirstChoiceBooksModel();

            var customer = new Customer
            {
                Name = name,
                EmailAddress = emailAddress
            };


            db.Customers.Add(customer);
            db.SaveChanges();
            db.Dispose();

            return customer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="description"></param>
        /// <param name="shippedDate"></param>
        /// <param name="shippedToAddress"></param>
        /// <returns></returns>
        public static Order CreateCustomerOrder(Customer customer, 
            string description, DateTime receivedDate, string shippedToAddress)
        {
            var db = new FirstChoiceBooksModel();

            var order = new Order
            {
                Customer = customer,
                Description = description,
                ReceivedDate = receivedDate,
                ShippedToAddress = shippedToAddress

            };

            // add line items here

            db.Orders.Add(order);
            db.SaveChanges();
            db.Dispose();

            return order;
        }

        /// <summary>
        /// Get Customer by Customer email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static Customer GetCustomerByCustomerEmail(string emailAddress)
        {
            var db = new FirstChoiceBooksModel();

            var customer = db.Customers.Where(c => c.EmailAddress == emailAddress).FirstOrDefault();
            if (customer == null)
                return null;

            return customer;
        }


        public static Order GetOrderByCustomerAndDescription(Customer customer, string description)
        {
            var db = new FirstChoiceBooksModel();

            var orderList = db.Orders.Where(ord =>ord.Customer.EmailAddress == customer.EmailAddress);

            Order searchResultOrder = null;

            foreach(Order order in orderList)
            {
                if (order.Description == description)
                {
                    searchResultOrder = order;
                }
            }

            return searchResultOrder;
        }

        /// <summary>
        /// create payment for a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public static Payment CreatePayment(Customer customer, decimal amount)
        {
            var db = new FirstChoiceBooksModel();

            var payment = new Payment
            {
                Customer = customer,
                Amount = amount
            };

            // add line items here

            db.Payments.Add(payment);
            db.SaveChanges();
            db.Dispose();

            return payment;
        }


        #endregion

    }
}
