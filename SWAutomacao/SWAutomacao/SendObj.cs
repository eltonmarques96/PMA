using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWAutomacao
{
    public class SendObj
    {
        [JsonProperty("item")]
        public string Item { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
