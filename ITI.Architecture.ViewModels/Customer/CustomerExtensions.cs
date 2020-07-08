using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public static class CustomerExtensions
    {
        public static CustomerViewModel ToViewModel(this Customer model)
        {
            return new CustomerViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone
            };
        }
        public static Customer ToModel(this CustomerEditViewModel editModel)
        {
            return new Customer
            {
                ID = editModel.ID,
                Name = editModel.Name,
                Email = editModel.Email,
                Phone = editModel.Phone,
                GroupID = editModel.GroupID
            };
        }
        public static CustomerEditViewModel ToEditableViewModel(this Customer model)
        {
            return new CustomerEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                GroupID = model.GroupID,
                Email = model.Email,
                Phone = model.Phone

            };
        }


    }
}
