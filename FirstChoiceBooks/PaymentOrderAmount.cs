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
        public virtual Order Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
