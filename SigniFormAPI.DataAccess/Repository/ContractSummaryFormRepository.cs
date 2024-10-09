using SigniFormAPI.DataAccess.Data;
using SigniFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.DataAccess.Repository
{
    public class ContractSummaryFormRepository : Repository<ContractSummaryForm>, IContractSummaryFormRepository
    {
        private ApplicationDbContext db;

        public ContractSummaryFormRepository(ApplicationDbContext db) : base(db) 
        {
            this.db = db;
        }

        public void Update(ContractSummaryForm obj)
        {
            db.ContractSummaries.Update(obj);
        }
    }
}
