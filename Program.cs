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



namespace wallpaperDl
{

        class Program
    {
        static void Main()
        {

            RunAsync().Wait(-1);

        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {


                                      string uri = "https://wallhaven.cc/api/v1/search?q=&purity=&categories=&page=&atleast=&sorting=&order=&apikey=";
                                      var uriBuilder = new UriBuilder(uri);
                                      uriBuilder.Port = -1;
                                      var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                                      Console.WriteLine("tagname - search fuzzily for a tag/-tagname - exclude a tag/+tag1 +tag2 - must have tag1 and +tag1 -tag2 - must have tag1 and NOT  \n @username - user   id:123 - Exact tag search (can not be combined  type:{png/jpg} - Search for file type (jpg = jpeg  like:wallpaper ID -\n Find wallpapers with similar tags\n");
                                      Console.WriteLine("query:\n\n");
                                      string q = Console.ReadLine();
                                      query["q"] = q;
                                      //  query["q"] = "  +  "
                                          Console.WriteLine("1920x1080,1920x1200\n\n");
                                      Console.WriteLine("Size:\n\n");
                                      string size = Console.ReadLine();
                                      query["atleast"] =size;
                                      query["apikey"] = "5TWcue0vWsGOfq4r6MYL1qofSALguBR4";

                                            Console.WriteLine("100*/110/111/etc (sfw/sketchy/nsfw)\n\n");
                                      Console.WriteLine("Purity\n\n");
                                      string purity = Console.ReadLine();
                                      query["purity"] =purity;


                                          Console.WriteLine("100/101/111*/etc (general/anime/people)\n\n");
                                      Console.WriteLine("categories:\n\n");
                                      string categories = Console.ReadLine();
                                      query["categories"] = categories;


                                          Console.WriteLine("int");
                                      Console.WriteLine("Page:\n\n");
                                      string pages = Console.ReadLine();
                                      query["page"] =pages;


                                          Console.WriteLine("date_added*, relevance, random, views, favorites, toplist\n\n");
                                      Console.WriteLine("Sorting:\n\n");
                                      string sorting = Console.ReadLine();
                                      query["sorting"] = sorting;



                                          Console.WriteLine("desc*, asc\n\n");
                                      Console.WriteLine("order:\n\n");
                                      string order = Console.ReadLine();
                                      query["order"] = order;



                                      uriBuilder.Query = query.ToString();
                                      uri = uriBuilder.ToString();



                HttpResponseMessage response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
               			 {

                    var result = await response.Content.ReadAsStringAsync();
										JObject url = JObject.Parse(result);

										for (int i = 0; i<=23; i++)
										{
										string urlPath = (string)url["data"][i]["path"];
										Uri uriAddress1 = new Uri(urlPath);
										var format = uriAddress1.Segments[3];
										Console.WriteLine("{0}  ##URL##", urlPath);
										 WebClient wb = new WebClient();
										 wb.DownloadFile(urlPath, format);

							}
						}
            else
            {
              Console.WriteLine("Things went wrong, Try Again\n");
            }
   			 }
  	  }
   }
}
