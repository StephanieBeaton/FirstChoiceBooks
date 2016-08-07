using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChoiceBooks
{
    public class PaymentOrderAmount
    {

        #region Properties

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        #endregion

        #region Constructors

        public PaymentOrderAmount()
        {

        }

        #endregion


        #region Methods

        #endregion

    }
}
