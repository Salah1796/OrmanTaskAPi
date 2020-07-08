using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Achitecture.Entities
{
    [Table("Invoice Item", Schema = "dbo")]
    public class InvoiceItem : BaseModel
    {
        public virtual Invoice Invoice { get; set; }
        [Required]
        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }


        public virtual Item Item { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]

        public double TotalPrice { get; set; }
    }
}
