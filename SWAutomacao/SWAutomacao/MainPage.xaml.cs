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
       
        static IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.0.100"), 2018);

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
                    await DisplayAlert("CÓDIGO DO PEDIDO", returndata/*await response.Content.ReadAsStringAsync()*/, "FECHAR");
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
            //Load();
            ////NetworkStream serverStream = clientSocket.GetStream();
            //byte[] outStream = System.Text.Encoding.ASCII.GetBytes("0:" + color);// BRANCO :0 
            ////serverStream.Write(outStream, 0, outStream.Length);          // AZUL :1 
            ////serverStream.Flush();                                        //VERMELHO :2

            //clientSocket.Send(outStream);


            //byte[] inStream = new byte[1024];
            //clientSocket.Receive(inStream);
            ////serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            //string returndata = System.Text.Encoding.UTF8.GetString(inStream);

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("192.168.0.90", 2018);

            Stream stream = tcpClient.GetStream();

            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();

            byte[] ByteArrayaSCIIEncoding = aSCIIEncoding.GetBytes(color);

            stream.Write(ByteArrayaSCIIEncoding, 0, ByteArrayaSCIIEncoding.Length);
            stream.Flush();

            byte[] ByteArrayReturnAscEnc = new byte[100];
            

            int k = stream.Read(ByteArrayReturnAscEnc, 0, 100);

            /*StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < k; i++)
            {
                if(!(ByteArrayReturnAscEnc[i] == 13 || ByteArrayReturnAscEnc[i] == 10))
                {
                    stringBuilder.Append(ByteArrayReturnAscEnc[i]);
                }   
            }*/
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
                    // await DisplayAlert("ENVIADO", returndata, "Fechar"); 
                    await DisplayAlert("CÓDIGO DO PEDIDO", returndata/*await response.Content.ReadAsStringAsync()*/, "FECHAR");
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
                    await DisplayAlert("CÓDIGO DO PEDIDO", returndata/*await response.Content.ReadAsStringAsync()*/, "FECHAR");
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
