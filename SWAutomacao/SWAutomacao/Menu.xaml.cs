using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWAutomacao
{
	public partial class Menu : ContentPage
    { 
        public Menu ()
		{
			InitializeComponent();
        }

        async void AnalyticsClick(object sender, EventArgs e)
        {
            var AnalyticsBtn = this.FindByName<Image>("AnalyticsBtn");
            if (AnalyticsBtn.IsEnabled)
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
                //await Navigation.PushAsync(new MainPage() { Title = "GRÁFICOS" });
            else
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
        }

        async void InfoClick(object sender, EventArgs e)
        {
            var InfoBtn = this.FindByName<Image>("InfoBtn");
            if (InfoBtn.IsEnabled)
                //await Navigation.PushAsync(new MainPage() { Title = "PESQUISAR" });
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
            else
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
        }
        async void ChatClick(object sender, EventArgs e)
        {
            var ChatBtn = this.FindByName<Image>("ChatBtn");
            if (ChatBtn.IsEnabled)
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
                //await Navigation.PushAsync(new MainPage() { Title = "CHAT" });
            else
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
        }

        async void SearchClick(object sender, EventArgs e)
        {
            var SearchBtn = this.FindByName<Image>("SearchBtn");
            if (InfoBtn.IsEnabled)
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
                //await Navigation.PushAsync(new MainPage() { Title = "AJUDA" });
            else
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
        }
        async void BoxClick(object sender, EventArgs e)
        {
            var BoxBtn = this.FindByName<Image>("BoxBtn");
            if (BoxBtn.IsEnabled)
                await Navigation.PushAsync(new MainPage() { Title = "PEDIDO" });
            else
                await DisplayAlert("ERRO", "PÁGINA INACESSÍVEL", "FECHAR");
        }

    }
}