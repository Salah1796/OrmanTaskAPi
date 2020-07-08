using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public class InvoiceItemViewModel
    {
      

        public int ID { get; set; }
      

        public int InvoiceID { get; set; }
      
        public string Item { get; set; }

       
        public int Quantity { get; set; }
       

        public double TotalPrice { get; set; }

    }
}
