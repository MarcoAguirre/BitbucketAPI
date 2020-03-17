using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitbucketApi
{
    public class Repository
    {
        [JsonProperty("name")]
        public string m_strRepositoryName;
        [JsonProperty("description")]
        public string m_strRepositoryCommentary;
    }
}
