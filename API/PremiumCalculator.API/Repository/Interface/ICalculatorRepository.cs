using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PremiumCalculator.API.Models.CalculatorModel;

namespace PremiumCalculator.API.Repository.Interface
{
    public interface ICalculatorRepository
    {
        /// <summary>
        /// Method providing list of occupations from database
        /// </summary>
        /// <returns></returns>
        List<OccupationModel> GetOccupationList();

        /// <summary>
        /// Method to get the rate factor based on the occupation
        /// </summary>
        /// <param name="occupationId"></param>
        /// <returns></returns>
        decimal GetRatingFactor(int occupationId);
    }
}
