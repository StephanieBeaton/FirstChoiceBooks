using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChoiceBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            // search for the customer in the database
            var customer = BookPrintingCompany.GetCustomerByCustomerEmail("alicemunro@test.com");

            // if customer not in database ...
            if (customer == null)
            { 
                // insert the new customer
                customer = BookPrintingCompany.CreateCustomer("Alice Munro", "alicemunro@test.com");
            }

            var orderDescription = "Print run of hard copy the book Runaway";

            var order = BookPrintingCompany.GetOrderByCustomerAndDescription(customer, orderDescription);

            // if customer's order not in database
            if (order == null)
            {
                // insert the new Order
                var receivedDate = new DateTime(2016, 7, 1);
                var shippedToAddress = "100 Main Street, Clinton, Ontario, Canada VR9 3T6";

                order = BookPrintingCompany.CreateCustomerOrder(customer,
                                                   orderDescription, receivedDate, shippedToAddress);
            }

            // =============================================================

            // search for the customer in the database
           customer = BookPrintingCompany.GetCustomerByCustomerEmail("alicemunro@test.com");

            // if customer is in database ...
            if (customer != null)
            {
                // check whether the customr has unpaid orders
                // var unpaidOrders = BookPrintingCompany.GetUnpaidCustomersUnpaidOrders(customer);

                // create a payment
                //if (unpaidOrders.Count > 0)
                //{
                    decimal amount = 1000.00m;

                    BookPrintingCompany.CreatePayment(customer, amount);
                //}

                // pay the orders
                //foreach (Order order in unpaidOrders)
                //{
                //    remainingAmount = BookPrintingCompany.PayOrder(customer, order, remainingAmount);
                //}
            }

 
            // var customer = BookPrintingCompany.CreateCustomer("Jane Austin", "jane@test.com");

        }
    }
}
