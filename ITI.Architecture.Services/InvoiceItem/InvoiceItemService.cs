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
    public class InvoiceItemService
    {
        UnitOfWork InvoiceItemOfWork;
        Generic<InvoiceItem> InvoiceItemRepo;
        public InvoiceItemService(UnitOfWork _InvoiceItemOfWork)
        {
            InvoiceItemOfWork = _InvoiceItemOfWork;
            InvoiceItemRepo = InvoiceItemOfWork.InvoiceItemRepo;
        }
        public InvoiceItemEditViewModel Add(InvoiceItemEditViewModel P)
        {
            InvoiceItem PP = InvoiceItemRepo.Add(P.ToModel());
            InvoiceItemOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public InvoiceItemEditViewModel Update(InvoiceItemEditViewModel P)
        {
            InvoiceItem PP = InvoiceItemRepo.Update(P.ToModel());
            InvoiceItemOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public InvoiceItem GetByID(int id)
        {
            return InvoiceItemRepo.GetByID(id);
        }

        public IEnumerable<InvoiceItemViewModel> GetAll()
        {
            var query =
                InvoiceItemRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }

        public void Remove(int id)
        {
            InvoiceItemRepo.Remove(InvoiceItemRepo.GetByID(id));
            InvoiceItemOfWork.Commit();
        }
    }
}
