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

        Dictionary<string, string> dicRepositoriesDataForTheListView = 
            new Dictionary<string, string>();

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

        //Este método está correcto, falta formatear bien el JSON
        public async Task<HttpResponseMessage> GETJSONRepositories(
            string strURL, string strUser, string strPassword)
        {
            Stream strContent;
            string strJSON = "";

            Values values;

            HttpRequestMessage httpRequest = new HttpRequestMessage(
                new HttpMethod("GET"), strURL + strUser);

            string vAuthorization = Convert.ToBase64String(
                Encoding.ASCII.GetBytes(strUser + ":" + strPassword));

            httpRequest.Headers.TryAddWithoutValidation(
                "Authorization", $"Basic {vAuthorization}");

            HttpResponseMessage response = await client.SendAsync(httpRequest);

            strContent = response.Content.ReadAsStreamAsync().Result;

            StreamReader reader = new StreamReader(strContent);

            strJSON = reader.ReadToEnd();

            values = JsonConvert.DeserializeObject<Values>(strJSON);

            return response;
        }

        public void SetRepositoryDataToTheListView(List<Repository> lstRepositoriesGained)
        {
            if (lstRepositoriesGained == null) return;

            dicRepositoriesDataForTheListView.Clear();

            foreach (Repository RepoItem in lstRepositoriesGained)
            {
                if (RepoItem == null) continue;

                dicRepositoriesDataForTheListView.Add(
                    RepoItem.m_strRepositoryName, RepoItem.m_strRepositoryCommentary);
            }

            lvRepositories.ItemsSource = dicRepositoriesDataForTheListView;
            lvRepositories.Items.Refresh();
        }

        //Este nuevo GET también está correcto, hay que leer bien el JSON
        public string NewGet()
        {
            string strRepoData = "";
            //Repository repository;
            //https://api.bitbucket.org/2.0/repositories/MarcoVAguirre/react/refs/branches

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                @"https://bitbucket.org/MarcoVAguirre/react.git\");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            strRepoData = reader.ReadToEnd();
            //repository = JsonConvert.DeserializeObject<Repository>(strRepoData);

            return strRepoData;
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            /*var response = Get();
            MessageBox.Show(Convert.ToString( response));*/

            //MessageBox.Show(GETJSON("https://api.bitbucket.org/2.0/repositories/MarcoVAguirre/react/refs/branches"));

            MessageBox.Show(GETJSONRepositories("Ingresar aqui el html", txtUserName.Text, 
              pbPassword.Password).ToString());

            //MessageBox.Show(NewGet());
        }
    }
}
