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
    public class InvoiceService
    {
        UnitOfWork unitOfWork;
        Generic<Invoice> InvoiceRepo;
        Generic<InvoiceItem> InvoiceItemRepo;

        public InvoiceService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            InvoiceRepo = unitOfWork.InvoiceRepo;
            InvoiceItemRepo = unitOfWork.InvoiceItemRepo;
        }
        public InvoiceEditViewModel Add(InvoiceEditViewModel P)
        {
            Invoice PP = InvoiceRepo.Add(P.ToModel());
            foreach (var item in P.InvoiceItems)
            {
                item.InvoiceID = PP.ID;
                InvoiceItemRepo.Add(item.ToModel());
            }
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public InvoiceEditViewModel Update(InvoiceEditViewModel P)
        {
            Invoice PP = InvoiceRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public InvoiceViewModel GetByID(int id)
        {
            return InvoiceRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<InvoiceViewModel> Get(int id, string name, string phone, int pageIndex, int pageSize = 20)
        {
            var query =
                InvoiceRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            InvoiceRepo.Remove(InvoiceRepo.GetByID(id));
            unitOfWork.Commit();
        }

        public IEnumerable<InvoiceViewModel> GetAll()
        {
            var query =
                InvoiceRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }
    }
}
