using System;
using static System.Console;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;



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
                                      WriteLine("tagname - search fuzzily for a tag/-tagname - exclude a tag/+tag1 +tag2 - must have tag1 and +tag1 -tag2 - must have tag1 and NOT  \n @username - user   id:123 - Exact tag search (can not be combined  type:{png/jpg} - Search for file type (jpg = jpeg  like:wallpaper ID -\n Find wallpapers with similar tags\n");
                                      WriteLine("query:\n\n");
                                      string q = ReadLine();
                                      query["q"] = q;
                                      //  query["q"] = "  +  "
                                          WriteLine("1920x1080,1920x1200\n\n");
                                      WriteLine("Size:\n\n");
                                      string size = ReadLine();
                                      query["atleast"] =size;
                                      query["apikey"] = "5TWcue0vWsGOfq4r6MYL1qofSALguBR4";

                                            WriteLine("100*/110/111/etc (sfw/sketchy/nsfw)\n\n");
                                      WriteLine("Purity\n\n");
                                      string purity = ReadLine();
                                      query["purity"] =purity;


                                          WriteLine("100/101/111*/etc (general/anime/people)\n\n");
                                   	 WriteLine("categories:\n\n");
                                      string categories = ReadLine();
                                      query["categories"] = categories;


                                          WriteLine("int");
                                      WriteLine("Page:\n\n");
                                      string pages = ReadLine();
                                      query["page"] =pages;


                                          WriteLine("date_added*, relevance, random, views, favorites, toplist\n\n");
                                      WriteLine("Sorting:\n\n");
                                      string sorting = ReadLine();
                                      query["sorting"] = sorting;



                                        WriteLine("desc*, asc\n\n");
                                      WriteLine("order:\n\n");
                                      string order = ReadLine();
                                      query["order"] = order;



                                      uriBuilder.Query = query.ToString();
                                      uri = uriBuilder.ToString();



                HttpResponseMessage response = await client.GetAsync(uri);
                    WriteLine(uri);

                if (response.IsSuccessStatusCode)
               			 {
                       try{

                        var result = await response.Content.ReadAsStringAsync();
                        JsonDocument url = JsonDocument.Parse(result);
                        JsonElement data = url.RootElement.GetProperty("data");

                        foreach (JsonElement i in data.EnumerateArray())
						{
                            if (i.TryGetProperty("path", out JsonElement el))
                            {
                                string urlPath = el.GetString();
                                Uri uriAddress1 = new Uri(urlPath);
                                var format = uriAddress1.Segments[3];
                                WriteLine("{0}  ##URL##", urlPath);
                                WebClient wb = new WebClient();
                                wb.DownloadFile(urlPath, format);
                            }
                        }
						}
			catch(ArgumentOutOfRangeException)
           	{
				
              WriteLine("Looooop ");
              RunAsync().Wait();
          	  }

         	 }

   		}
  	}
   }
}
