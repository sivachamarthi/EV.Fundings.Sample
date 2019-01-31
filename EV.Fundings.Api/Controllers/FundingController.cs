using EV.Fundings.Api.Models.ResourceModels;
using EV.Fundings.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Controllers
{
    [ApiController]
    public class FundingController : ControllerBase
    {
        private readonly IFundingService _fundingService;
        public FundingController(IFundingService fundingService)
        {
            _fundingService = fundingService;
        }

        /// <summary>
        /// Get all the fundings
        /// </summary>
        /// <returns></returns>
        [HttpGet("/funding/getall")]
        [ProducesResponseType(typeof(IEnumerable<FundingModel>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var fundings = await _fundingService.GetFundings();
            return new ObjectResult(fundings);
        }


        /// <summary>
        /// Get the elevator with id passed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/funding/{id}", Name = "Get_Funding")]
        [ProducesResponseType(typeof(FundingModel), 200)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var funding = await _fundingService.GetFunding(id);
            if (funding != null)
                return new ObjectResult(funding);
            else
                return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.NotFound };
        }

        /// <summary>
        /// Updates a funding investment
        /// </summary>
        /// <param name="fundingModel"></param>
        /// <returns></returns>
        [HttpPut("/funding/update")]
        [ProducesResponseType(typeof(FundingModel), 200)]
        public async Task<IActionResult> Update([FromBody]FundingModel fundingModel)
        {
            if (!ModelState.IsValid)
            {
                return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var funding = await _fundingService.UpdateFunding(fundingModel);

            return new ObjectResult(funding) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}
