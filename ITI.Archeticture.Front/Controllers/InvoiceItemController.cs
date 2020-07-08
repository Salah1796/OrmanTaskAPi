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

    public class InvoiceItemController : ApiController
    {
        InvoiceItemService InvoiceItemService;
        public InvoiceItemController(InvoiceItemService _InvoiceItemService)
        {
            InvoiceItemService = _InvoiceItemService;


        }
        [HttpGet]
        public ResultViewModel<IEnumerable<InvoiceItemViewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<InvoiceItemViewModel>> result
                 = new ResultViewModel<IEnumerable<InvoiceItemViewModel>>();

            try
            {

                result.Successed = true;
                result.Data = InvoiceItemService.GetAll(); ;

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;


        }
        [HttpGet]
        public ResultViewModel<InvoiceItemViewModel> GetByID(int id)
        {
            ResultViewModel<InvoiceItemViewModel> result
                = new ResultViewModel<InvoiceItemViewModel>();
            try
            {

                result.Successed = true;
                result.Data = InvoiceItemService.GetByID(id).ToViewModel();
                if (result.Data == null)
                    result.Message = "Invoiceitem Not Found !";

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
            if (InvoiceItemService.GetByID(id) != null)
            {
                InvoiceItemService.Remove(id);
                return "Invoiceitem Deleted Sucessfully";
            }
            else
                return "Invoiceitem Not Found !";
        }

        [HttpPost]
        public ResultViewModel<InvoiceItemEditViewModel> Update(InvoiceItemEditViewModel emp)
        {
            ResultViewModel<InvoiceItemEditViewModel> result
                = new ResultViewModel<InvoiceItemEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    InvoiceItemEditViewModel selectedEmp
                        = InvoiceItemService.Update(emp);

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
        public ResultViewModel<InvoiceItemEditViewModel> Add(InvoiceItemEditViewModel emp)
        {
            ResultViewModel<InvoiceItemEditViewModel> result
                = new ResultViewModel<InvoiceItemEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    InvoiceItemEditViewModel selectedEmp
                        = InvoiceItemService.Add(emp);

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











