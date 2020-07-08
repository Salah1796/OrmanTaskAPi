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
    public class ItemService
    {
        UnitOfWork unitOfWork;
        Generic<Item> ItemRepo;
        public ItemService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ItemRepo = unitOfWork.ItemRepo;
        }
        public ItemEditViewModel Add(ItemEditViewModel P)
        {
            Item PP = ItemRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public ItemEditViewModel Update(ItemEditViewModel P)
        {
            Item PP = ItemRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public ItemViewModel GetByID(int id)
        {
            return ItemRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<ItemViewModel> Get(int id, string name, string phone, int pageIndex, int pageSize = 20)
        {
            var query =
                ItemRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            ItemRepo.Remove(ItemRepo.GetByID(id));
            unitOfWork.Commit();
        }

        public IEnumerable<ItemViewModel> GetAll()
        {
            var query =
                ItemRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }
    }
}
