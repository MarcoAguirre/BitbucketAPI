using System;
using System.Collections.Generic;
using System.Windows;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace BitbucketApi
{
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();        
        }

        public async Task<string> Get()
        {
            HttpResponseMessage responseJson = await client.GetAsync("http://www.google.com.ec");
            HttpContent content = responseJson.Content;
            string strContentResponse = await content.ReadAsStringAsync();


            return strContentResponse;
        }

        public string GETJSON(string strURL)
        {
            string strJSON = "";

            WebRequest webRequest = WebRequest.Create(strURL);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;
            webResponse = (HttpWebResponse)webRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            strJSON = streamReader.ReadToEnd();
            streamReader.Close();

            return strJSON;
        }

        public async Task<HttpResponseMessage> GETJSONRepositories(string strURL, string strUser, string strPassword)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(new HttpMethod("GET"), strURL + strUser);
            string vAuthorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(strUser + ":" + strPassword));
            httpRequest.Headers.TryAddWithoutValidation("Authorization", $"Basic {vAuthorization}");

            HttpResponseMessage response = await client.SendAsync(httpRequest);

            return response;
        }

        public string NewGet()
        {
            string strRepoData = "";
            Repository repository;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                @"https://api.bitbucket.org/2.0/repositories/MarcoVAguirre/react/refs/branches");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            strRepoData = reader.ReadToEnd();
            repository = JsonConvert.DeserializeObject<Repository>(strRepoData);


            return repository.StrRepositoryName;
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            /*var response = Get();
            MessageBox.Show(Convert.ToString( response));*/

            //MessageBox.Show(GETJSON("https://api.bitbucket.org/2.0/repositories/MarcoVAguirre/react/refs/branches"));

            //MessageBox.Show(GETJSONRepositories("https://api.bitbucket.org/2.0/repositories/", txtUserName.Text, 
            //  pbPassword.Password).ToString());

            MessageBox.Show(NewGet());
        }
    }
}
