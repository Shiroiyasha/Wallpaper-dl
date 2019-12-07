using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace ProductStoreClient
{
    
        class Program
    {
        static void Main()
        {

            RunAsync().Wait();
            
        }
        		
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("https://wallhaven.cc/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string uri = "https://wallhaven.cc/api/v1/search?q=&purity=111&page=5&atleast=";
                var uriBuilder = new UriBuilder(uri);
                uriBuilder.Port = -1;
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["q"] = "cyberpunk";
              //  query["q"] = "  +  "
                query["atleast"] ="1920x1080";
                query["apikey"] = "5TWcue0vWsGOfq4r6MYL1qofSALguBR4";
                uriBuilder.Query = query.ToString();
                uri = uriBuilder.ToString();
               
                HttpResponseMessage response = await client.GetAsync(uri);
               
               
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
					JObject url = JObject.Parse(result);
						for (int i = 0; i<=26; i++) 
							{					
						string urlPath = (string)url["data"][i]["path"];
						Uri uriAddress1 = new Uri(urlPath);
						var format = uriAddress1.Segments[3];
						Console.WriteLine("{0} <= ##URL##, {1} <= ##Title##", urlPath,format);
						WebClient wb = new WebClient(); 
						wb.DownloadFile(urlPath, format);
						
							}
						}
   			 }
  	  }	
   }
}