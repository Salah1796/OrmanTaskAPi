using ITI.Achitecture.Entities;
using ITI.Architecture.Repositories;
using ITI.Architecture.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.Services
{
    public class CustomerService
    {
        
        UnitOfWork unitOfWork;
        Generic<Customer> CustomerRepo;
        public CustomerService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CustomerRepo = unitOfWork.CustomerRepo;
        }
        public CustomerEditViewModel Add(CustomerEditViewModel P)
        {
            Customer PP = CustomerRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public CustomerEditViewModel Update(CustomerEditViewModel P)
        {
            Customer PP = CustomerRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public CustomerViewModel GetByID(int id)
        {
            return CustomerRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<CustomerViewModel> Get(int id, string name, string phone, int pageIndex, int pageSize = 20)
        {
            var query =
                CustomerRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CustomerRepo.Remove(CustomerRepo.GetByID(id));
            unitOfWork.Commit();
        }
        public IEnumerable<CustomerViewModel> GetAll()
        {
            var query =
                CustomerRepo.GetAll();
            return query.ToList().Select(i => i.ToViewModel());
        }
    }
}
