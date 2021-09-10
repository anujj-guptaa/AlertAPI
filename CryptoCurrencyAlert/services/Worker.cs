using CryptoCurrencyAlert.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoCurrencyAlert.services
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private int number = 0;
        static HttpClient client = new HttpClient();
        private readonly IEmailSender EmailSender;
        //   public List<Currency> Currencies { get; set; }
        public Worker(ILogger<Worker> logger, IEmailSender emailSender)
        {
            this.logger = logger;
            this.EmailSender = emailSender;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                string path = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=USD&order=market_cap_desc & per_page = 100 & page = 1 & sparkline = false";
                HttpResponseMessage response = await client.GetAsync(path);

                // logger.LogInformation(response.Content.ReadAsStringAsync().Result);
               // string json = response.Content.ReadAsStringAsync().Result;
                var result = await response.Content.ReadAsStringAsync();
              //  dynamic deserializedValue = JsonConvert.DeserializeObject(result);

                JArray array = JArray.Parse(result);
                //string[,] array11 = new string[,];
               // List<List<Dictionary<string,string>> x = new List<List<string>>();
                foreach (JObject obj in array.Children<JObject>())
                {
                    //List<string> y = new List<string>();
                    //    Dictionary<string, string>
                    Dictionary<string, string> d = new Dictionary<string, string>();
                    foreach (JProperty singleProp in obj.Properties())
                    {
                        string name = singleProp.Name;
                        string value = singleProp.Value.ToString();
                       



                        if (name=="name" || name=="current_price")

                        { 
                            
                            d.Add(name, value);
                            
                        }
                        
                    }

                    // x.Add(y);
                    JsonConvert.SerializeObject(d);
                }
                

                string path1 = "https://localhost:44373/api/AlertDatas";
                HttpResponseMessage response1 = await client.GetAsync(path1);

              
                var result1 = await response1.Content.ReadAsStringAsync();
               
                JArray array1 = JArray.Parse(result1);
                foreach (JObject obj1 in array1.Children<JObject>())
                {
                    
                    foreach (JProperty singleProp in obj1.Properties())
                    {
                        string name = singleProp.Name;
                        string value = singleProp.Value.ToString();
                        if(name=="email")
                        {
                            await EmailSender.SendEmailAsync(value, "Hello", "alert price raised");
                        }

                    }
                    // x.Add(y);
                  
                }
               
              
                await Task.Delay(1000 * 25);
            }
        }
    }
}
