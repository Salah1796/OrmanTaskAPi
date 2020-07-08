using ITI.Architecture.Services;
using ITI.Architecture.ViewModels;
using ITI.Architecture.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ITI.Archeticture.Presentation
{

    public class InvoiceController : ApiController
    {
        InvoiceService InvoiceService;
        public InvoiceController(InvoiceService _InvoiceService)
        {
            InvoiceService = _InvoiceService;


        }
        [HttpGet]
        public ResultViewModel<IEnumerable<InvoiceViewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<InvoiceViewModel>> result
                 = new ResultViewModel<IEnumerable<InvoiceViewModel>>();

            try
            {

                result.Successed = true;
                result.Data = InvoiceService.GetAll(); ;

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;


        }
        [HttpGet]
        public ResultViewModel<InvoiceViewModel> GetByID(int id)
        {
            ResultViewModel<InvoiceViewModel> result
                = new ResultViewModel<InvoiceViewModel>();
            try
            {

                result.Successed = true;
                result.Data = InvoiceService.GetByID(id);
                if (result.Data == null)
                    result.Message = "Invoice Not Found !";

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
            if (InvoiceService.GetByID(id) != null)
            {
                InvoiceService.Remove(id);
                return "Invoice Deleted Sucessfully";
            }
            else
                return "Invoice Not Found !";
        }

        [HttpPost]
        public ResultViewModel<InvoiceEditViewModel> Update(InvoiceEditViewModel emp)
        {
            ResultViewModel<InvoiceEditViewModel> result
                = new ResultViewModel<InvoiceEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    InvoiceEditViewModel selectedEmp
                        = InvoiceService.Update(emp);

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
        public ResultViewModel<InvoiceEditViewModel> Add(InvoiceEditViewModel inv)
        {

            ResultViewModel<InvoiceEditViewModel> result
                = new ResultViewModel<InvoiceEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    InvoiceEditViewModel selectedEmp
                        = InvoiceService.Add(inv);

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











