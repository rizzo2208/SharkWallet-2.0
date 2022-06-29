using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharkWallet_2._0.Models;
using System.Text.Json;

namespace SharkWallet_2._0.entidades
{
    public class ConsumirApiService : IConsumirApiService
    {
        private HttpClient _httpClient;
        public async Task<Ethereum> GetValor()
        {
            Ethereum resultado = new Ethereum();
            
            _httpClient = new HttpClient();
            string url = "https://api.coingecko.com/api/v3/simple/price?ids=ethereum&vs_currencies=usd";
            using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url))
            {
                using (HttpResponseMessage response = await _httpClient.SendAsync(req))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseStringContent = await content.ReadAsStringAsync();
                            Console.WriteLine(responseStringContent);
                            resultado.Usd = responseStringContent;
                            int LnResETH = resultado.Usd.Length;
                            char[] PrecioETH = new char[LnResETH];
                            PrecioETH = resultado.Usd.ToCharArray();

                            int papa = PrecioETH.Length;
                            int[] valornum = new int[19+(papa-5)];
                            int valornu=0;

                            for (int i = 19; i < (papa-5); i++)
                            {
                                valornum[i] = Convert.ToInt32(Char.GetNumericValue(PrecioETH[i]));
                            }

                            if (Int32.TryParse(string.Join("", valornum), out valornu))
                            {
                            Console.WriteLine(valornu);                          
                                resultado.Usd2 = valornu;
                                return resultado; //success - handle the number
                            }
                            else
                            {
                                return resultado;//failed - too many digits in the array
                            }
                            /*char[] quees = new char[LnResETH];
                            for (int i = 0; i < LnResETH; i++)
                            {
                                bool esEspacio = Char.IsSeparator(PrecioETH[i]);
                                bool esNumero = Char.IsLetter(PrecioETH[i]);
                                bool esMayus = Char.IsUpper(PrecioETH[i]);
                                if (esEspacio == true)
                                {
                                    quees[i] = 'e';
                                }
                                else if (esNumero == false)
                                {
                                    //Console.WriteLine(i);
                                    quees[i] = 'n';
                                }
                                else if (esMayus == true)
                                {
                                    //Console.WriteLine("letra M");
                                    quees[i] = 'M';
                                }
                                else if (esMayus == false)
                                {
                                    //Console.WriteLine("letra m");
                                    quees[i] = 'm';
                                }
                            }
                            for (int i = 0; i < LnResETH; i++)
                            {
                                Console.WriteLine(quees[i]);
                            }*/

                            return resultado;

                        }
                        else
                        {
                            //resultado.Usd = "error";
                            return resultado;
                        }
                    }
                }
            }

            
        }

    }
}

