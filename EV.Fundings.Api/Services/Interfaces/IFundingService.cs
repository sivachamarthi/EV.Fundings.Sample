using EV.Fundings.Api.Models.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Services.Interfaces
{
    public interface IFundingService
    {
        Task<IEnumerable<FundingModel>> GetFundings();

        Task<FundingModel> GetFunding(int id);

        Task<FundingModel> UpdateFunding(FundingModel fundingModel);
    }
}
