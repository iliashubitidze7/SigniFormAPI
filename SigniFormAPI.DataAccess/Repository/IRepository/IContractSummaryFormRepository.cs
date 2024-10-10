using SigniFormAPI.DataAccess.Repository.IRepository;
using SigniFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.DataAccess.Repository
{
    public interface IContractSummaryFormRepository : IRepository<ContractSummaryForm>
    {
        public void Update(ContractSummaryForm obj);
    }
}
