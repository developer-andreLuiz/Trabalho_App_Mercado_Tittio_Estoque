using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Trabalho_App_Mercado_Tittio_Estoque.Helpers
{
    public class DeviceHelper
    {
        public static bool InternetCheck()
        {
            try
            {
                using (var client = new WebClient())
                {
                    WebProxy wp = new WebProxy();
                    client.Proxy = wp;
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
