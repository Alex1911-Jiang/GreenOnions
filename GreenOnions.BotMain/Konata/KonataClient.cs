using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.Konata;

namespace GreenOnions.BotMain.Konata
{
    public class KonataClient
    {
        public void Login()
        {
            Client client = new Client();
            client.Login();
        }
    }
}
