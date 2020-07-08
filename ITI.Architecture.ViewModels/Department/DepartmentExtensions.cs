using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public static class DepartmentExtensions
    {
        public static DepartmentViewModel ToViewModel(this Department model)
        {
            return new DepartmentViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                OpenDate=model.OpenDate
            };
        }
        public static Department ToModel(this DepartmentEditViewModel editModel)
        {
            return new Department()
            {
                ID = editModel.ID,
                Name = editModel.Name,
                OpenDate=editModel.OpenDate
            };
        }
        public static DepartmentEditViewModel ToEditableViewModel(this Department model)
        {
            return new DepartmentEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                OpenDate=model.OpenDate
            };
        }
    }
}
