using System;
using System.Collections.Generic;
using System.Windows;
using System.Net.Http;
using System.Threading.Tasks;

namespace BitbucketApi
{
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            dynamic response = Get();
            MessageBox.Show(response.ToString());
        }

        public async Task<dynamic> Get()
        {
            HttpResponseMessage responseJson = await client.GetAsync("http://www.etnassoft.com/api/v1/get/?id=589&callback=?");
            HttpContent content = responseJson.Content;


            return content.ReadAsStringAsync();
        }
    }
}
