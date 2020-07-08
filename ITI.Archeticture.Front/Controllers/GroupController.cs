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

    public class GroupController : ApiController
    {
       GroupService groupService;
        public GroupController(GroupService _groupService)
        {
            groupService = _groupService;


        }
        [HttpGet]
        public ResultViewModel<IEnumerable<GroupViewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<GroupViewModel>> result
                 = new ResultViewModel<IEnumerable<GroupViewModel>>();

            try
            {

                result.Successed = true;
                result.Data =groupService.GetAll(); ;

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;


        }
        [HttpGet]
        public ResultViewModel<GroupViewModel> GetByID(int id)
        {
            ResultViewModel<GroupViewModel> result
                = new ResultViewModel<GroupViewModel>();
            try
            {

                result.Successed = true;
                result.Data =groupService.GetByID(id);
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
            if (groupService.GetByID(id) != null)
            {
                groupService.Remove(id);
                return "Group Deleted Sucessfully";
            }
            else
                return "Group Not Found !";
        }

        [HttpPost]
        public ResultViewModel<GroupEditViewModel> Update(GroupEditViewModel emp)
        {
            ResultViewModel<GroupEditViewModel> result
                = new ResultViewModel<GroupEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    GroupEditViewModel selectedEmp
                        =groupService.Update(emp);

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
        public ResultViewModel<GroupEditViewModel> Add(GroupEditViewModel inv)
        {

            ResultViewModel<GroupEditViewModel> result
                = new ResultViewModel<GroupEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    GroupEditViewModel selectedEmp
                        =groupService.Add(inv);

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











