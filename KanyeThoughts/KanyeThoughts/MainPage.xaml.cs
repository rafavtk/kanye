using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json;


namespace KanyeThoughts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Gerar(object sender, EventArgs e)
        {
            PuxarApi();
        }

        private HttpClient _client = new HttpClient();
        async Task PuxarApi()
        {
            try
            {
                Pensamentos pensamentos = new Pensamentos();

                string APIUrl = String.Format("https://api.kanye.rest/");
                HttpResponseMessage response = await _client.GetAsync(APIUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();


                    //deserializando o json e colocando na classe ParametrosClima()
                    pensamentos = JsonConvert.DeserializeObject<Pensamentos>(json);


                    BindingContext = pensamentos;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                    
            }
        }
    }
}
