using SigniFormAPI.DataAccess.Data;
using SigniFormAPI.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        public IContractSummaryFormRepository ContractSummary { get; set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            ContractSummary = new ContractSummaryFormRepository(db);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
