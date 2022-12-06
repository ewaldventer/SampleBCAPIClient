using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIClient.Models
{
    public class StringResponse
    {
        public string odatacontext { get; set; }
        public string value { get; set; }
    }

    public class IntResponse
    {
        public string odatacontext { get; set; }
        public int value { get; set; }
    }


    public class ErrorResponse
    {
        public Error error { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class CountResponse
    {
        [JsonProperty("@odata.count")]
        public int odatacount { get; set; }
    }
}
