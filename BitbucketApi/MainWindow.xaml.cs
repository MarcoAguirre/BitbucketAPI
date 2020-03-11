using System;
using System.Collections.Generic;
using System.Windows;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;

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
            //string strRepoData = "";

            HttpRequestMessage httpRequest = new HttpRequestMessage(new HttpMethod("GET"), strURL + strUser);
            string vAuthorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(strUser + ":" + strPassword));
            httpRequest.Headers.TryAddWithoutValidation("Authorization", $"Basic {vAuthorization}");

            HttpResponseMessage response = await client.SendAsync(httpRequest);

            return response;
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            /*var response = Get();
            MessageBox.Show(Convert.ToString( response));*/

            //MessageBox.Show(GETJSON("http://www.google.com.ec"));

            MessageBox.Show(GETJSONRepositories("https://api.bitbucket.org/2.0/repositories/", txtUserName.Text, 
                pbPassword.Password).ToString());
        }
    }
}
