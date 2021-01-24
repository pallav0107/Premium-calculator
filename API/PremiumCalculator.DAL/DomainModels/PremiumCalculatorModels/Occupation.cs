using System;
using System.Collections.Generic;

namespace PremiumCalculator.DAL.DomainModels.PremiumCalculatorModels
{
    public partial class Occupation
    {
        public int OccupationId { get; set; }
        public string Occupation1 { get; set; }
        public int RatingId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual OccupationRating Rating { get; set; }
    }
}
