using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.API.Models
{
    public class CalculatorModel
    {
        /// <summary>
        /// Occupation model
        /// </summary>
        public class OccupationModel
        {
            public int OccupationId { get; set; }
            public string Occupation { get; set; }

        }

        /// <summary>
        /// Customer model
        /// </summary>
        public class CustomerModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Dob{ get; set; }
            public int OccupationId { get; set; }
            public decimal SumInsured { get; set; }
        }

    }
}
