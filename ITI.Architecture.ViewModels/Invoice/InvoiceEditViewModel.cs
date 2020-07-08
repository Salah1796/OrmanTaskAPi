using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public class InvoiceEditViewModel
    {

        [Required]
       
        public int ID { get; set; }
        [Required]
      
        public int CustomerID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]

        public double TotalPrice { get; set; }
        public  List<InvoiceItemEditViewModel> InvoiceItems { get; set; }
    }
}
