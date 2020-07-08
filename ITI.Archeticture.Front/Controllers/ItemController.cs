using ITI.Architecture.Services;
using ITI.Architecture.ViewModels;
using ITI.Architecture.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.Archeticture.Presentation.Controller
{
    
    public class ItemController : ApiController
    {
        ItemService ItemService;
        public ItemController(ItemService _ItemService)
        {
            ItemService = _ItemService;
        

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<ItemViewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<ItemViewModel>> result
                 = new ResultViewModel<IEnumerable<ItemViewModel>>();

            try
            {
               
                    result.Successed = true;
                    result.Data = ItemService.GetAll();;
                
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;

           
        }
        [HttpGet]
        public ResultViewModel<ItemViewModel> GetByID(int id)
        {
            ResultViewModel<ItemViewModel> result
                = new ResultViewModel<ItemViewModel>();
            try
            {
                
                result.Successed = true;
                result.Data = ItemService.GetByID(id);
                if (result.Data == null)
                    result.Message = "Emplyee Not Found !";

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpGet]
        public string Delete(int id)
        {
            if (ItemService.GetByID(id) != null)
            {
                ItemService.Remove(id);
                return "Emplyee Deleted Sucessfully";
            }
            else
                return "Emplyee Not Found !";
        }

        [HttpPost]
        public ResultViewModel<ItemEditViewModel> Update(ItemEditViewModel emp)
        {
            ResultViewModel<ItemEditViewModel> result
                = new ResultViewModel<ItemEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    ItemEditViewModel selectedEmp
                        = ItemService.Update(emp);

                    result.Successed = true;
                    result.Data = selectedEmp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }

        [HttpPost]
        public ResultViewModel<ItemEditViewModel> Add(ItemEditViewModel emp)
        {
            ResultViewModel<ItemEditViewModel> result
                = new ResultViewModel<ItemEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Item Name";
                }
                else
                {
                    ItemEditViewModel selectedEmp
                        = ItemService.Add(emp);
                    
                    result.Successed = true;
                    result.Data = selectedEmp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }




    }
}










    
