using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SWAutomacao
{
    public partial class MainPage : ContentPage
    {
        
        bool enable = true;
        
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
       
        static IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.0.90"), 2018);

        Socket clientSocket = new Socket(remoteEP.AddressFamily, SocketType.Stream,ProtocolType.Tcp);


        public MainPage()
        {            
            InitializeComponent();
        }
        
        public async void OnClickWhitePadlock(object sender, EventArgs e)
        {
            SendObj obj = new SendObj() { Item = "cadeado", Color = "0" }; //0 branco

            if (enable)
            {
                enable = false;
                //var contentPost = new StringContent(new SerializerObj().Test(obj).ToString(), Encoding.UTF8, "application/json");
                try
                {
                    //HttpResponseMessage response = await webService.PostAsync(host, contentPost);
                    string returndata = OnSend(obj.Color, obj.Item);
                    while (returndata != "" && returndata != null)
                    {
                        await DisplayAlert("AGUARDE", "EM PRODUÇÃO", "FECHAR");
                    }
                    await DisplayAlert("CÓDIGO DO PEDIDO", returndata, "FECHAR");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", "Tente novamente", "FECHAR");
                }
                enable = true;
            }
        }

        private string OnSend(string color, string item)
        {
            
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("192.168.0.90", 2018);

            Stream stream = tcpClient.GetStream();

            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();

            byte[] ByteArrayaSCIIEncoding = aSCIIEncoding.GetBytes(color);

            stream.Write(ByteArrayaSCIIEncoding, 0, ByteArrayaSCIIEncoding.Length);
            stream.Flush();

            byte[] ByteArrayReturnAscEnc = new byte[100];
            

            int k = stream.Read(ByteArrayReturnAscEnc, 0, 100);

            string result = System.Text.Encoding.UTF8.GetString(ByteArrayReturnAscEnc);

            return result;
        }

        private void Load()
        {
            clientSocket.Connect(remoteEP);
        }

        public async void OnClickRedPadlock(object sender, EventArgs e)
        {
            SendObj obj = new SendObj() { Item = "Cadeado", Color = "2" }; //2 vermelho

            if (enable)
            {
                enable = false;
                //var contentPost = new StringContent(new SerializerObj().Test(obj).ToString(), Encoding.UTF8, "application/json");
                try
                {
                    //HttpResponseMessage response = await webService.PostAsync(host, contentPost);
                    string returndata = OnSend(obj.Color, obj.Item);
                    while (returndata != "" && returndata != null)
                    {
                        await DisplayAlert("AGUARDE", "EM PRODUÇÃO", "FECHAR");
                    }
                    await DisplayAlert("CÓDIGO DO PEDIDO", returndata, "FECHAR");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "FECHAR");
                }
                enable = true;
            }
        }
        public async void OnClickBluePadlock(object sender, EventArgs e)
        {
            SendObj obj = new SendObj() { Item = "cadeado", Color = "1" };//AZUL :1

            if (enable)
            {
                enable = false;
                //var contentPost = new StringContent(new SerializerObj().Test(obj).ToString(), Encoding.UTF8, "application/json");
                try
                {
                    //HttpResponseMessage response = await webService.PostAsync(host, contentPost);
                    string returndata = OnSend(obj.Color, obj.Item);
                    while (returndata != "" && returndata != null)
                    {
                        await DisplayAlert("AGUARDE", "EM PRODUÇÃO", "FECHAR");
                    }

                    await DisplayAlert("CÓDIGO DO PEDIDO", returndata, "FECHAR");
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
