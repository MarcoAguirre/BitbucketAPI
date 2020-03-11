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
        }

        public async Task<string> Get()
        {
            HttpResponseMessage responseJson = await client.GetAsync("http://www.google.com.ec");
            HttpContent content = responseJson.Content;
            string strContentResponse = await content.ReadAsStringAsync();


            return strContentResponse;
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            var response = Get();
            MessageBox.Show(Convert.ToString( response));
        }
    }
}
