using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PremiumCalculator.API.Services.Interface;
using PremiumCalculator.Common;
using static PremiumCalculator.API.Models.CalculatorModel;

namespace PremiumCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumCalcController : BaseController
    {

        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Cart Api Service
        /// </summary>
        private ICalculatorService calcService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="calcService"></param>
        public PremiumCalcController(IConfiguration configuration, ICalculatorService calcService) : base(configuration)
        {
            this.configuration = configuration;
            this.calcService = calcService;
        }

        /// <summary>
        /// Returns list of Occupations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<OccupationModel>), (int)HttpStatusCode.OK)]
        [Route("/GetOccupations")]
        public IActionResult GetOccupations()
        {
            try
            {
                InitializeCorelation();

                var occupationList = calcService.GetOccupationList();
                if (occupationList != null && occupationList.Count() > 0)
                {
                    return Ok(occupationList);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Calculates the premium based on the customer input request data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [Route("/CalculatePremium")]
        public IActionResult ProcessCheckoutOrder([FromBody] CustomerModel request)
        {
            try
            {
                InitializeCorelation();

                if (request == null)
                {
                    return BadRequest("Invalid Request");
                }

                var response = calcService.CalculatePremium(request);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
