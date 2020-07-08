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
    public class GroupService
    {
        
        UnitOfWork unitOfWork;
        Generic<Group> GroupRepo;
        public GroupService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            GroupRepo = unitOfWork.GroupRepo;
        }
        public GroupEditViewModel Add(GroupEditViewModel P)
        {
            Group PP = GroupRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public GroupEditViewModel Update(GroupEditViewModel P)
        {
            Group PP = GroupRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public GroupViewModel GetByID(int id)
        {
            return GroupRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<GroupViewModel> Get(int id, string name, string phone, int pageIndex, int pageSize = 20)
        {
            var query =
                GroupRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            GroupRepo.Remove(GroupRepo.GetByID(id));
            unitOfWork.Commit();
        }
        public IEnumerable<GroupViewModel> GetAll()
        {
            var query =
                GroupRepo.GetAll();
            return query.ToList().Select(i => i.ToViewModel());
        }
    }
}
