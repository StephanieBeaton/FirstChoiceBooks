using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChoiceBooks
{
    public class Customer
    {
        #region Variables
        #endregion

        #region Properties
        /// <summary>
        /// Customer's Id - unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Customer's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer's payment method - credit card, check, cash
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        public string EmailAddress { get; set; }

        #endregion

        #region Constructors

        public Customer()
        {

        }

        #endregion


        #region Methods

        public string CalculateCustomerReliability()
        {
            var result = "very reliable";

            // loop thru Orders and see how often PaymentReceivedDate > PaymentDueDate

            return result;
        }

        public string ToString()
        {
            var customerString = "Customer Id: " + Id + "\n" +
                                 "Name: " + Name + "\n" +
                                 "PaymentMethod: " + PaymentMethod + "\n" +
                                 "EmailAddress: " + EmailAddress;

            return customerString;
        }
        #endregion
    }
}
