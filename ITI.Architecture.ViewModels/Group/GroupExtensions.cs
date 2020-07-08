using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public static class GroupExtensions
    {
        public static GroupViewModel ToViewModel(this Group model)
        {
            return new GroupViewModel
            {
                ID = model.ID,
                Name = model.Name,
                 
               

            };
        }
        public static Group ToModel(this GroupEditViewModel editModel)
        {
            return new Group
            {
                ID = editModel.ID,
                Name=editModel.Name,
                

            };
        }
        public static GroupEditViewModel ToEditableViewModel(this Group model)
        {
            return new GroupEditViewModel
            {
                ID = model.ID,
                Name=model.Name,
                
            };
        }


    }
}
