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
        #endregion

    }
}
