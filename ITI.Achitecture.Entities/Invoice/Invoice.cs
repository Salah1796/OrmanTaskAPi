using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Achitecture.Entities
{
    [Table("Invoice ", Schema = "dbo")]
    public class Invoice : BaseModel
    {
        public  virtual Customer Customer { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
