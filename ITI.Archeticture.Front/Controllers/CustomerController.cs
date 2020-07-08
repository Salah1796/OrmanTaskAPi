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

    public class CustomerController : ApiController
    {
        CustomerService customerService;
        public CustomerController(CustomerService _customerervice)
        {
            customerService = _customerervice;


        }
        [HttpGet]
        public ResultViewModel<IEnumerable<CustomerViewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<CustomerViewModel>> result
                 = new ResultViewModel<IEnumerable<CustomerViewModel>>();

            try
            {

                result.Successed = true;
                result.Data = customerService.GetAll(); ;

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;


        }
        [HttpGet]
        public ResultViewModel<CustomerViewModel> GetByID(int id)
        {
            ResultViewModel<CustomerViewModel> result
                = new ResultViewModel<CustomerViewModel>();
            try
            {

                result.Successed = true;
                result.Data = customerService.GetByID(id);
                if (result.Data == null)
                    result.Message = "Customer Not Found !";

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
            if (customerService.GetByID(id) != null)
            {
                customerService.Remove(id);
                return "Customer Deleted Sucessfully";
            }
            else
                return "Customer Not Found !";
        }

        [HttpPost]
        public ResultViewModel<CustomerEditViewModel> Update(CustomerEditViewModel emp)
        {
            ResultViewModel<CustomerEditViewModel> result
                = new ResultViewModel<CustomerEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CustomerEditViewModel selectedEmp
                        = customerService.Update(emp);

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
        public ResultViewModel<CustomerEditViewModel> Add(CustomerEditViewModel inv)
        {

            ResultViewModel<CustomerEditViewModel> result
                = new ResultViewModel<CustomerEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CustomerEditViewModel selectedEmp
                        = customerService.Add(inv);

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











