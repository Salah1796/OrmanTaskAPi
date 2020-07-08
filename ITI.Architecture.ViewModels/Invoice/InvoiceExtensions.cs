using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public static class InvoiceExtensions
    {
        public static InvoiceViewModel ToViewModel(this Invoice model)
        {
            return new InvoiceViewModel
            {
                ID = model.ID,
                Date = model.Date,
                TotalPrice = model.TotalPrice,
                CustomerName = model.Customer?.Name,
                InvoiceItems = model.InvoiceItems.Select(i => i.ToViewModel()).ToList()
            };
        }
        public static Invoice ToModel(this InvoiceEditViewModel editModel)
        {
            return new Invoice
            {
                ID = editModel.ID,
                Date = editModel.Date,
                CustomerID = editModel.CustomerID,
                TotalPrice = editModel.TotalPrice

            };
        }
        public static InvoiceEditViewModel ToEditableViewModel(this Invoice model)
        {
            return new InvoiceEditViewModel
            {
                ID = model.ID,
                Date = model.Date,
                TotalPrice = model.TotalPrice,
                CustomerID = model.CustomerID
            };
        }


    }
}
