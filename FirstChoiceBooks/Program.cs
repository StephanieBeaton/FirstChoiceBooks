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

            // ==================================================================================
            //
            //   process first customer
            //
            // ==================================================================================

            // search for the customer in the database
            var customer = BookPrintingCompany.GetCustomerByCustomerEmail("alicemunro@test.com");

            // if customer not in database ...
            if (customer == null)
            { 
                // insert the new customer
                customer = BookPrintingCompany.CreateCustomer("Alice Munro", "alicemunro@test.com");
            }

            var orderDescription = "Print run of hard copy the book Runaway";

            // search for order in database
            var order = BookPrintingCompany.GetOrderByCustomerAndDescription(customer, orderDescription);

            var receivedDate = new DateTime(2016, 7, 1);
            var shippedToAddress = "100 Main Street, Clinton, Ontario, Canada VR9 3T6";
            decimal totalPrice = 1000.00m;

            decimal paidAmount = 1000.00m;
            decimal remainingAmount = paidAmount;

            Payment payment;

            // if customer's order not in database
            if (order == null)
            {
                // insert the new Order

                order = BookPrintingCompany.CreateCustomerOrder(customer,
                                                   orderDescription, receivedDate, shippedToAddress, totalPrice);
            }

            paidAmount = 2500.00m;

            // create payment from customer
            payment = BookPrintingCompany.CreatePayment(customer, paidAmount);

            // if customer is in database ...
            if (customer != null)
            {
                BookPrintingCompany.PayCustomerUnpaidOrders(customer, payment);
            }

            // ==================================================================================
            //
            //   process second customer
            //
            // ==================================================================================


            var customer2 = BookPrintingCompany.CreateCustomer("Jane Austin", "jane@test.com");

            // insert the first Order
            orderDescription = "Print run of soft backed copy the book Pride and Prejudice";
            receivedDate = new DateTime(2016, 7, 1);
            shippedToAddress = "100 Main Street, Steventon, UK, VR9 3T6";
            totalPrice = 2000.00m;

            order = BookPrintingCompany.CreateCustomerOrder(customer2,
                                               orderDescription, receivedDate, shippedToAddress, totalPrice);

            // insert the second Order
            orderDescription = "Print run of soft backed copy the book Sense and Sensibility";
            receivedDate = new DateTime(2016, 7, 1);
            shippedToAddress = "100 Main Street, Steventon, UK, VR9 3T6";
            totalPrice = 500.00m;

            order = BookPrintingCompany.CreateCustomerOrder(customer2,
                                               orderDescription, receivedDate, shippedToAddress, totalPrice);

            paidAmount = 2500.00m;

            // create payment from customer
            payment = BookPrintingCompany.CreatePayment(customer2, paidAmount);

            BookPrintingCompany.PayCustomerUnpaidOrders(customer2, payment);


            // ==================================================================================
            //
            //   month end reporting
            //
            // ==================================================================================

            var customers = BookPrintingCompany.GetCustomers();

            foreach (Customer c in customers)
            {
                var orders = BookPrintingCompany.GetCustomerOrders(c);
                var payments = BookPrintingCompany.GetCustomerPayments(c);
            }

        }
    }
}
