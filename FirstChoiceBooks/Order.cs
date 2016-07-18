using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChoiceBooks
{
    public class Order
    {
        #region Variables
        #endregion

        #region Properties

        /// <summary>
        /// Order's Id - unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Order's Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// date the order was received
        /// </summary>
        public DateTime ReceivedDate { get; set; }

        /// <summary>
        /// date the order was shipped
        /// </summary>
        public DateTime ShippedDate { get; set; }

        /// <summary>
        /// date payment was due
        /// </summary>
        public DateTime PaymentDueDate { get; set; }

        /// <summary>
        /// date full payment is received
        /// </summary>
        public DateTime PaymentReceivedDate { get; set; }

        /// <summary>
        /// Address where order is to be shipped
        /// </summary>
        public string ShippedToAddress   { get; set; }

        /// <summary>
        /// Total Price of the order
        /// </summary>
        public decimal TotalPrice { get; set; }

        public virtual Customer Customer { get; set; }

        #endregion

        #region Constructors

        public Order()
        {
        }

        #endregion

        #region Methods

        public decimal CalculateTotalPrice()
        {
            var total = 0;

            // loop through order line items and add them up
            return total;
        }

        public string ToString()
        {
            var orderString = "Id: " + Id + "\n" +
                                 "Description: " + Description + "\n" +
                                "ReceivedDate: " + ReceivedDate + "\n" +
                                 "ShippedDate: " + ShippedDate + "\n" +
                                 "PaymentDueDate: " + PaymentDueDate + "\n" +
                                 "PaymentReceivedDate: " + PaymentReceivedDate + "\n" +
                                 "ShippedToAddress: " + ShippedToAddress + "\n" +
                                 "TotalPrice: " + TotalPrice + "\n" +
                                 "Customer Id: " + Customer.Id;

            return orderString;
        }
        #endregion

    }
}
