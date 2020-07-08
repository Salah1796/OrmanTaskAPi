using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public static class ItemExtensions
    {
        public static ItemViewModel ToViewModel(this Item model)
        {
            return new ItemViewModel
            {
                ID = model.ID,
                Name = model.Name,
                 Price=model.Price
               

            };
        }
        public static Item ToModel(this ItemEditViewModel editModel)
        {
            return new Item
            {
                ID = editModel.ID,
                Name=editModel.Name,
                Price=editModel.Price


            };
        }
        public static ItemEditViewModel ToEditableViewModel(this Item model)
        {
            return new ItemEditViewModel
            {
                ID = model.ID,
                Name=model.Name,
                Price=model.Price
            };
        }


    }
}
