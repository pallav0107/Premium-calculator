using AutoMapper;
using PremiumCalculator.DAL.DomainModels.PremiumCalculatorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PremiumCalculator.API.Models.CalculatorModel;

namespace PremiumCalculator.API.Mapping
{
    /// <summary>
    /// Mapping profile to map models
    /// </summary>
    public class CalculatorMappingProfile : Profile
    {
        public CalculatorMappingProfile()
        {
            //Database to DTO
            #region Database to DTO
            CreateMap<Occupation, OccupationModel>()
                                        .ForMember(dest => dest.OccupationId, opts => opts.MapFrom(src => src.OccupationId))
                                        .ForMember(dest => dest.Occupation, opts => opts.MapFrom(src => src.Occupation1));

            #endregion
            //DTO to Database

            #region DTO to Database

            #endregion
        }

    }
}
