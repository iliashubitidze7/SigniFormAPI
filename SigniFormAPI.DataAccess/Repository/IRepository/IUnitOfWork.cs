using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IContractSummaryFormRepository ContractSummary {  get; }
        void Save();
    }
}
