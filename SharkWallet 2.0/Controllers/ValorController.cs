using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SharkWallet_2._0.Controllers
{
    public class ValorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public void GetItem(string id)
        {
            var url = $"https://api.coingecko.com/api/v3/simple/price?ids={id}" + $"&vs_currencies=usd";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }
    }
}
