using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitbucketApi
{
    public class Values
    {
        [JsonProperty("pagelen")]
        public int m_iPageLenght;
        [JsonProperty("values")]
        public List<Repository> m_lstListOfValues;
    }
}
