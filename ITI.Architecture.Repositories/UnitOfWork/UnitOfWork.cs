using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.Repositories
{
    public class UnitOfWork
    {
        private EnitiesContext context;
        public Generic<Customer> CustomerRepo { get; set; }
        public Generic<Group> GroupRepo { get; set; }
        public Generic<Invoice> InvoiceRepo { get; set; }
        public Generic<Item> ItemRepo { get; set; }
        public Generic<InvoiceItem> InvoiceItemRepo { get; set; }



        public UnitOfWork(
            EnitiesContext _context,
            Generic<Group> groupRepo,
            Generic<Customer> customerRepo,
            Generic<Invoice> invoiceRepo,
            Generic<Item> itemRepo,
            Generic<InvoiceItem> invoiceItemRepo
            )
        {
            context = _context;
            CustomerRepo = customerRepo;
            CustomerRepo.Context = context;
            GroupRepo = groupRepo;
            GroupRepo.Context = context;
            InvoiceRepo = invoiceRepo;
            InvoiceRepo.Context = context;
            ItemRepo = itemRepo;
            ItemRepo.Context = context;
            InvoiceItemRepo = invoiceItemRepo;
            InvoiceItemRepo.Context = context;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
