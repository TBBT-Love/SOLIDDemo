using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine _engine)
        {

            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), new object[] { _engine, _engine.Logger });
            }

            catch
            {
                return new UnknownPolicyRater(_engine, _engine.Logger);
            }
            //switch (policy.Type)
            //{
            //    case PolicyType.Auto:
            //        return new AutoPolicyRater(_engine, _engine.Logger);

            //    case PolicyType.Land:
            //        return new LandPolicyRater(_engine, _engine.Logger);

            //    case PolicyType.Life:
            //        return new LifePolicyRater(_engine, _engine.Logger);

            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(_engine, _engine.Logger);
            //    default:
            //        null;
            //}
        }
    }
}
