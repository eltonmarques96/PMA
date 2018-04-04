using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SWAutomacao
{
    public partial class MainPage : ContentPage
    {
        public static HttpClient webService = new HttpClient();
        public string host = @"http://httpbin.org/post";
        bool enable = true;

        public MainPage()
        {
            SetWebService(host);
            InitializeComponent();
        }

        static void SetWebService(string Url)
        {
            if (Url.Trim() != "")
                webService.BaseAddress = new Uri(Url);
        }
        public async void OnClickWhitePadlock(object sender, EventArgs e)
        {
            SendObj obj = new SendObj() { Item = "cadeado", Color = "branco" };

            if (enable)
            {
                enable = false;
                var contentPost = new StringContent(new SerializerObj().Test(obj).ToString(), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await webService.PostAsync(host, contentPost);
                    
                    await DisplayAlert("BRANCO", await response.Content.ReadAsStringAsync(), "FECHAR");

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", "Tente novamente", "FECHAR");
                }
                enable = true;
            }
        }
        public async void OnClickRedPadlock(object sender, EventArgs e)
        {
            SendObj obj = new SendObj() { Item = "cadeado", Color = "vermelho" };

            if (enable)
            {
                enable = false;
                var contentPost = new StringContent(new SerializerObj().Test(obj).ToString(), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await webService.PostAsync(host, contentPost);
                    await DisplayAlert("VERMELHO", await response.Content.ReadAsStringAsync(), "FECHAR");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", "Tente novamente", "FECHAR");
                }
                enable = true;
            }
        }
        public async void OnClickBluePadlock(object sender, EventArgs e)
        {
            SendObj obj = new SendObj() { Item = "cadeado", Color = "azul" };

            if (enable)
            {
                enable = false;
                var contentPost = new StringContent(new SerializerObj().Test(obj).ToString(), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await webService.PostAsync(host, contentPost);
                    await DisplayAlert("AZUL", await response.Content.ReadAsStringAsync(), "FECHAR");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", "Tente novamente", "FECHAR");
                }
                enable = true;
            }
        }
    }
}
