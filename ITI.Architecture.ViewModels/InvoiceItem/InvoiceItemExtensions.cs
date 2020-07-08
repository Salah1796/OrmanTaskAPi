using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public static class InvoiceItemExtensions
    {
        public static InvoiceItemViewModel ToViewModel(this InvoiceItem model)
        {
            return new InvoiceItemViewModel
            {
                ID = model.ID,
                Item = model.Item.Name,
                InvoiceID = model.InvoiceID,
                Quantity = model.Quantity,
                TotalPrice = model.TotalPrice

            };
        }
        public static InvoiceItem ToModel(this InvoiceItemEditViewModel editModel)
        {
            return new InvoiceItem
            {
                ID = editModel.ID,

                TotalPrice = editModel.TotalPrice,

                InvoiceID = editModel.InvoiceID,

                Quantity = editModel.Quantity,
                ItemID = editModel.ItemID,



            };
        }
        public static InvoiceItemEditViewModel ToEditableViewModel(this InvoiceItem model)
        {
            return new InvoiceItemEditViewModel
            {
                ID = model.ID,
                TotalPrice = model.TotalPrice,

                InvoiceID = model.InvoiceID,

                Quantity = model.Quantity,
                ItemID = model.ItemID


            };
        }


    }
}
