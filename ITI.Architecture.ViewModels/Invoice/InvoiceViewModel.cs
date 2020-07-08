using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public class InvoiceViewModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public List<InvoiceItemViewModel> InvoiceItems { get; set; }

    }
}
