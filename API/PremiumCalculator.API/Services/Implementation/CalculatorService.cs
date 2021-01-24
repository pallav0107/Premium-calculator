using PremiumCalculator.API.Models;
using PremiumCalculator.API.Repository.Interface;
using PremiumCalculator.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PremiumCalculator.API.Models.CalculatorModel;

namespace PremiumCalculator.API.Services.Implementation
{
    public class CalculatorService : ICalculatorService
    {
        public ICalculatorRepository calculatorRepository { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CalculatorService(ICalculatorRepository repository)
        {
            calculatorRepository = repository;
        }

        /// <summary>
        /// Service method to calculate the premium 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public decimal CalculatePremium(CustomerModel request)
        {
            var ratingFactor = calculatorRepository.GetRatingFactor(request.OccupationId);

            //Death Premium = (Death Cover amount *Occupation Rating Factor *Age) / 1000 * 12

            var premium = ((request.SumInsured * ratingFactor * request.Age) / 1000) * 12;

            return premium;
        }

        /// <summary>
        /// Service method to retreive list of occupation
        /// </summary>
        /// <returns>list of type <see cref="OccupationModel"/></returns>
        public List<OccupationModel> GetOccupationList()
        {
            var occupationList = calculatorRepository.GetOccupationList();

            return occupationList;
        }
    }
}
