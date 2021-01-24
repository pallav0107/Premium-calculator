using System;
using System.Collections.Generic;

namespace PremiumCalculator.DAL.DomainModels.PremiumCalculatorModels
{
    public partial class OccupationRating
    {
        public OccupationRating()
        {
            Occupation = new HashSet<Occupation>();
        }

        public int RatingId { get; set; }
        public string Rating { get; set; }
        public decimal Factor { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Occupation> Occupation { get; set; }
    }
}
