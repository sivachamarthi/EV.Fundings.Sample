using EV.Fundings.Api.Data.Interfaces;
using EV.Fundings.Api.Models.ResourceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Data.Repositories
{
    public class FundingRepository : IFundingRepository
    {
        private readonly EVDbContext _context;
        public FundingRepository(EVDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FundingModel>> GetFundings()
        {
            var fundings = from f in _context.Funding
                           select new FundingModel()
                           {
                               Id = f.Id,
                               Name = f.Name,
                               Description = f.Description,
                               InvestmentAmount = f.InvestmentAmount,
                               IsInvested = f.IsInvested,
                               CreateDate = f.CreateDate,
                               CreatedBy = f.CreatedBy
                           };

            return await fundings.ToListAsync();
        }

        public async Task<FundingModel> GetFunding(int id)
        {
            var funding = from f in _context.Funding
                          where f.Id == id
                           select new FundingModel()
                           {
                               Id = f.Id,
                               Name = f.Name,
                               Description = f.Description,
                               InvestmentAmount = f.InvestmentAmount,
                               IsInvested = f.IsInvested,
                               CreateDate = f.CreateDate,
                               CreatedBy = f.CreatedBy
                           };

            return await funding.FirstOrDefaultAsync();
        }

        public async Task<FundingModel> UpdateFunding(FundingModel fundingModel)
        {
            var funding = await _context.Funding.Where(f => f.Id == fundingModel.Id).FirstOrDefaultAsync();

            if (funding != null)
            {
                funding.InvestmentAmount = fundingModel.InvestmentAmount;
                funding.IsInvested = true;
                await _context.SaveChangesAsync();
            }

            fundingModel = await GetFunding(fundingModel.Id);
            return fundingModel;
        }
    }
}
