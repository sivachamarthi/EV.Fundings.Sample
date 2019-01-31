using EV.Fundings.Api.Controllers;
using EV.Fundings.Api.Models.ResourceModels;
using EV.Fundings.Api.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EV.Fundings.Api.Tests.UnitTests
{
    public class FundingControllerUnitTests
    {
        private readonly Mock<IFundingService> fundingServiceMock;
        public FundingControllerUnitTests()
        {
            fundingServiceMock = new Mock<IFundingService>();
        }

        [Fact]
        public async Task Get_All_Fundings()
        {
            //Arrange 
            fundingServiceMock.Setup(es => es.GetFundings())
                .Returns(() => Task.FromResult(GetFundings(5)));

            FundingController fundingController = new FundingController(fundingServiceMock.Object);

            //Action
            var result = await fundingController.GetAll();

            //Assert
            var objResult = result.Should().BeOfType<ObjectResult>().Subject;
            var fundingList = objResult.Value.Should().BeOfType<List<FundingModel>>().Subject;
            fundingList.Count().Should().Be(5);
        }


        #region Test Fixtures
        public IEnumerable<FundingModel> GetFundings(int count = 1)
        {
            var fundings = new List<FundingModel>()
            {
                new FundingModel()
                {
                    Id = 1,
                    Name = "Tegel Complex",
                    Description = "New Complex in Tegel area.",
                    IsInvested = false,
                    InvestmentAmount = null,
                    CreateDate = DateTime.Now.AddDays(-4),
                    CreatedBy = "System"
                },
                 new FundingModel()
                     {
                         Id = 2,
                         Name = "Mitte Complex",
                         Description = "New Complex in Mitte area.",
                         IsInvested = false,
                         InvestmentAmount = null,
                         CreateDate = DateTime.Now.AddDays(-2),
                         CreatedBy = "System"
                     },
                      new FundingModel()
                      {
                          Id = 3,
                          Name = "Schoneberg Complex",
                          Description = "New Complex in Schoneberg area.",
                          IsInvested = false,
                          InvestmentAmount = null,
                          CreateDate = DateTime.Now.AddDays(-3),
                          CreatedBy = "System"
                      },
                       new FundingModel()
                       {
                           Id = 4,
                           Name = "Berlin Complex",
                           Description = "New Complex in Central Berlin area.",
                           IsInvested = false,
                           InvestmentAmount = null,
                           CreateDate = DateTime.Now.AddDays(-1),
                           CreatedBy = "System"
                       },
                        new FundingModel()
                        {
                            Id = 5,
                            Name = "Tegel Complex",
                            Description = "New Complex in Tegel area.",
                            IsInvested = false,
                            InvestmentAmount = null,
                            CreateDate = DateTime.Now.AddDays(-4),
                            CreatedBy = "System"
                        }
            };

            return fundings.Take(count).ToList();
        }
        #endregion
    }
}
