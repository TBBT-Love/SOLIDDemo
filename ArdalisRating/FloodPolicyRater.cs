using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
            //_engine = engine;
            //_logger = logger;
        }
        public override void Rate(Policy policy)
        {
            _logger.Log("Rating Flood policy...");
            _logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))//Validation
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }
                _engine.Rating = 900m;
            }
        }
    }
}
