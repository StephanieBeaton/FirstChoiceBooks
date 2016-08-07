using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstChoiceBooks
{
    public class Payment
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        #endregion

        #region Constructors

        public Payment()
        {

        }

        #endregion
        #region Methods

        #endregion
    }
}
