using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;

namespace SWAutomacao
{
    public class SerializerObj
    {
        public string Test(object obj)//Serializa(?) o objeto para enviar para o WebService
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
