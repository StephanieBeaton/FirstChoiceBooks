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

        /// <summary>
        /// Create a Customer
        /// </summary>
        /// <param name="name">customer name</param>
        /// <param name="emailAddress">customer email address</param>
        /// <returns></returns>
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
        /// Create a customer's order
        /// </summary>
        /// <param name="customer">a customer instance</param>
        /// <param name="description">description of order</param>
        /// <param name="shippedDate">date the order is to be shipped</param>
        /// <param name="shippedToAddress">address the order is to be shipped to</param>
        /// <returns></returns>
        public static Order CreateCustomerOrder(Customer customer,
            string description, DateTime receivedDate, string shippedToAddress, decimal totalPrice)
        {
            var db = new FirstChoiceBooksModel();

            var order = new Order
            {
                CustomerId = (int)customer.Id,
                Description = description,
                ReceivedDate = receivedDate,
                ShippedToAddress = shippedToAddress,
                TotalPrice = totalPrice

            };

            // add line items here

            db.Orders.Add(order);
            db.SaveChanges();
            db.Dispose();

            return order;
        }

        /// <summary>
        /// Get Customer by Customer email address
        /// ... email address should be unique
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

        /// <summary>
        /// Get Customers unpaid orders by email address
        /// </summary>
        /// <param name="emailAddress">email address</param>
        /// <returns>list of unpaid orders</returns>
        public static IEnumerable<Order> GetCustomerUnpaidOrdersByEmailAddress(string emailAddress)
        {
            var db = new FirstChoiceBooksModel();

            var unpaidOrderList = db.Orders
                .Where(ord => ord.Customer.EmailAddress == emailAddress)
                .Where(ord => ord.PaymentReceivedDate == null);

            return unpaidOrderList;
        }

        /// <summary>
        /// Get order given customer and order description
        /// ...should identify unique order
        /// </summary>
        /// <param name="customer">customer whose order it is</param>
        /// <param name="description">description of order</param>
        /// <returns></returns>
        public static Order GetOrderByCustomerAndDescription(Customer customer, string description)
        {
            var db = new FirstChoiceBooksModel();

            var orderList = db.Orders.Where(ord => ord.Customer.EmailAddress == customer.EmailAddress);

            Order searchResultOrder = null;

            foreach (Order order in orderList)
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
        /// <param name="customer">customer whose making the payment</param>
        /// <param name="Amount">payment amount</param>
        /// <returns></returns>
        public static Payment CreatePayment(Customer customer, decimal amount)
        {
            var db = new FirstChoiceBooksModel();

            var payment = new Payment
            {
                CustomerId = (int)customer.Id,
                Amount = amount
            };

            db.Payments.Add(payment);
            db.SaveChanges();
            db.Dispose();

            return payment;
        }

        /// <summary>
        /// get the customer's orders where payment received date is null
        /// </summary>
        /// <param name="customer">customer instance</param>
        /// <returns>enumerable list of unpaid orders belonging to the customer</returns>
        public static IEnumerable<Order> GetUnpaidCustomersUnpaidOrders(Customer customer)
        {
            var db = new FirstChoiceBooksModel();

            var unpaidOrderList = db.Orders
                .Where(ord => ord.Customer.EmailAddress == customer.EmailAddress)
                .Where(ord => ord.PaymentReceivedDate == null);

            return unpaidOrderList;
        }

        /// <summary>
        /// pay a customer's unpaid order
        /// ... insert a row into the PaymeentOrderAmounts table for each order paid
        /// </summary>
        /// <param name="unpaidOrder">an unpaid order belonging to a customer</param>
        /// <param name="payment">payment instance representing payment and date customer made the payment</param>
        /// <param name="remainingAmount">amount remaining from the payment that can be used to pay the unpaid order</param>
        /// <returns></returns>
        public static decimal PayOrder(Order unpaidOrder, Payment payment, decimal remainingAmount)
        {
            // insert row into PaymentOrderAmounts table
            var db = new FirstChoiceBooksModel();

            decimal amountPaid = 0.00m;

            if (unpaidOrder.TotalPrice > remainingAmount)
            {
                amountPaid = remainingAmount;
                remainingAmount = 0.00m;
            }
            else
            {
                amountPaid = unpaidOrder.TotalPrice;
                remainingAmount -= unpaidOrder.TotalPrice;
            }

            var paymentOrderAmount = new PaymentOrderAmount
            {
                Amount = amountPaid,
                OrderId = (int)unpaidOrder.Id,
                PaymentId = (int)payment.Id
            };

            db.PaymentOrderAmounts.Add(paymentOrderAmount);
            db.SaveChanges();
            db.Dispose();

            return remainingAmount;
        }

        /// <summary>
        /// get customers orders
        /// </summary>
        /// <param name="customer">customer instance</param>
        /// <returns>list of customers orders</returns>
        public static IEnumerable<Order> GetCustomerOrders(Customer customer)
        {
            var db = new FirstChoiceBooksModel();

            var orderList = db.Orders
                .Where(ord => ord.Customer.EmailAddress == customer.EmailAddress);

            return orderList;
        }

        /// <summary>
        /// get list of customers
        /// </summary>
        /// <returns>list of customers</returns>
        public static IEnumerable<Customer> GetCustomers()
        {
            var db = new FirstChoiceBooksModel();

            var customersList = db.Customers;

            return customersList;
        }

        public static IEnumerable<Payment> GetCustomerPayments(Customer customer)
        {
            var db = new FirstChoiceBooksModel();

            var paymentList = db.Payments
                .Where(payment => payment.CustomerId == customer.Id);

            return paymentList;
        }

        /// <summary>
        /// pay the unpaid orders of a customer until payment money runs out
        /// </summary>
        /// <param name="customer">customer whose unpaid orders are being paid</param>
        /// <param name="payment">payment customer made</param>
        /// <returns>true is successful</returns>
        public static Boolean PayCustomerUnpaidOrders(Customer customer, Payment payment)
        {
            var unpaidOrders = BookPrintingCompany.GetUnpaidCustomersUnpaidOrders(customer);

            // create a payment
            Boolean allOrdersPaidFlag = true;

            // Note for Kal
            // I could't use an if statement with condition testing Count here
            // ... because IEnumerable does't have Count
            foreach (Order unpaidOrder in unpaidOrders)
            {
                allOrdersPaidFlag = false;
                break;
            }

            if (allOrdersPaidFlag == false)
            {
                // pay the orders
                var remainingAmount = payment.Amount;

                foreach (Order unpaidOrder in unpaidOrders)
                {
                    if (remainingAmount == 0.00m) break;

                    remainingAmount = BookPrintingCompany.PayOrder(unpaidOrder, payment, remainingAmount);
                }
            }

            return true;
        }   

    #endregion

}
}
