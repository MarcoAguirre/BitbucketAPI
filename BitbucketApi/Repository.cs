using System;
using System.Collections.Generic;
using System.Text;

namespace BitbucketApi
{
    public class Repository
    {
        string m_strRepositoryName = "";
        string m_strRepositoryCommentary = "";

        public string StrRepositoryName 
        { 
            get => m_strRepositoryName; 
            set => m_strRepositoryName = value; 
        }

        public string StrRepositoryCommentary 
        { 
            get => m_strRepositoryCommentary; 
            set => m_strRepositoryCommentary = value; 
        }
    }
}
