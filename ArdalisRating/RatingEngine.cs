using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        public PolicySerializer PolicySerializer { get; set; } = new PolicySerializer();

        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource(); //Persistence

            var policy = PolicySerializer.GetPolicyfromJSONString(policyJson); //encoding format

            var factory = new RaterFactory();
            var rater = factory.Create(policy, this);
            rater.Rate(policy);
            Logger.Log("Rating completed.");

            //switch (policy.Type)
            //{
            //    case PolicyType.Auto: //Business logic
            //        var rater = new AutoPolicyRater(this, this.Logger);
            //        rater.Rate(policy);
            //        break;
            //    case PolicyType.Land:
            //        var landRater = new LandPolicyRater(this, this.Logger);
            //        landRater.Rate(policy);
            //        break;
            //    case PolicyType.Life:
            //        var lifeRater = new LifePolicyRater(this, this.Logger);
            //        lifeRater.Rate(policy);
            //        break;
            //    default:
            //        Logger.Log("Unknown policy type");
            //        break;
            //}


        }
    }
}
