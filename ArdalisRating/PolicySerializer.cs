using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class PolicySerializer
    {
        public Policy GetPolicyfromJSONString(string inputPolicyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(inputPolicyJson,
                new StringEnumConverter());
        }
    }
}
