using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChoiceBooks
{
    public class LineItem
    {
        #region Variables
        #endregion

        #region Properties
        /// <summary>
        /// Line Item's Id - unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Line Item's description
        /// </summary>
        public string Description  { get; set; }

        /// <summary>
        /// Line item's price = Unit price * quantity
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of the Line Item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// each Line Item belongs to an Order
        /// </summary>
        public Order Order;

        #endregion

        #region Constructors

        public LineItem()
        {

        }

        #endregion

        #region Methods

        public decimal CalculateLineItemDiscount()
        {
            // discount depends on Customer Reliability
            decimal discount = 0.0M;

            return discount; 
        }

        public string ToString()
        {
            var lineItemString = "Id: " + Id + "\n" +
                                 "Description: " + Description + "\n" +
                                 "Price: " + Price + "\n" +
                                 "Order Id: " + Order.Id;

            return lineItemString;
        }
        #endregion
    }
}
