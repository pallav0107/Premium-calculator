using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PremiumCalculator.API.Models.CalculatorModel;

namespace PremiumCalculator.API.Services.Interface
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Gets the list of Occupation
        /// </summary>
        /// <returns></returns>
        List<OccupationModel> GetOccupationList();

        /// <summary>
        /// Service method to retreive list of occupation
        /// </summary>
        /// <returns>list of type <see cref="OccupationModel"/></returns>
        decimal CalculatePremium(CustomerModel request);
    }
}
