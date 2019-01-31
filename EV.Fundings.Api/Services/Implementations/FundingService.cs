using EV.Fundings.Api.Data.Interfaces;
using EV.Fundings.Api.Models.ResourceModels;
using EV.Fundings.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Services.Implementations
{
    public class FundingService : IFundingService
    {
        private readonly IFundingRepository _fundingRepository;
        public FundingService(IFundingRepository fundingRepository)
        {
            _fundingRepository = fundingRepository;
        }

        public async Task<IEnumerable<FundingModel>> GetFundings()
        {
            return await _fundingRepository.GetFundings();
        }

        public async Task<FundingModel> GetFunding(int id)
        {
            return await _fundingRepository.GetFunding(id);
        }

        public async Task<FundingModel> UpdateFunding(FundingModel fundingModel)
        {
            return await _fundingRepository.UpdateFunding(fundingModel);
        }
    }
}
