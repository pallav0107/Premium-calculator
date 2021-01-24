using AutoMapper;
using PremiumCalculator.API.Models;
using PremiumCalculator.API.Repository.Interface;
using PremiumCalculator.DAL.Databases;
using PremiumCalculator.DAL.DomainModels.PremiumCalculatorModels;
using PremiumCalculator.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PremiumCalculator.API.Models.CalculatorModel;

namespace PremiumCalculator.API.Repository.Implementation
{
    public class CalculatorRepository : BaseRepository, ICalculatorRepository
    {
        private readonly TALContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tContext"></param>
        /// <param name="mapper"></param>
        public CalculatorRepository(TALContext tContext, IMapper mapper) : base(tContext, mapper)
        {
            context = tContext;
        }

        /// <summary>
        /// Method providing list of occupations from database
        /// </summary>
        /// <returns></returns>
        public List<OccupationModel> GetOccupationList()
        {
            List<OccupationModel> mappedresult = new List<OccupationModel>();

            DBAccess(context =>
                {
                    var dbResult = context.Occupation.Select(x => x);

                    mappedresult = m_mapper.Map<List<Occupation>, List<OccupationModel>>(dbResult.ToList());

                }, false);

            return mappedresult;
        }

        /// <summary>
        /// Method to get the rate factor based on the occupation
        /// </summary>
        /// <param name="occupationId"></param>
        /// <returns></returns>
        public decimal GetRatingFactor(int occupationId)
        {
            decimal result = 0;
            DBAccess(context =>
            {
                var requestRatingId = context.Occupation.Where(x => x.OccupationId == occupationId).Select(c => c.RatingId).FirstOrDefault();
                if (requestRatingId > 0)
                {
                    result = context.OccupationRating.Where(x => x.RatingId == requestRatingId).Select(f => f.Factor).FirstOrDefault();
                }
                
            }, false);

            return result;
        }
    }
}
