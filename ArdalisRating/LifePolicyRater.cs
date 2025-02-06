using System;

namespace ArdalisRating
{
    public class LifePolicyRater: Rater
    {
        //private readonly RatingEngine _engine;
        //private ConsoleLogger _logger;

        public LifePolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }
        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
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
