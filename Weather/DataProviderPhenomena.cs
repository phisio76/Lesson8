using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Weather
{
    class DataProviderPhenomena
    {
        static Dictionary<string, string> urls;
        static DataProviderPhenomena()
        {
            urls = new Dictionary<string, string>();
            urls.Add("Москва", @"https://xml.meteoservice.ru/export/gismeteo/point/32277.xml");
            urls.Add("Белгород", @"https://xml.meteoservice.ru/export/gismeteo/point/112.xml");
        }

        HttpClient httpClient;

        public DataProviderPhenomena()
        {
            httpClient = new HttpClient();
        }
        public ObservableCollection<WeatherModelPhenomena> GetWetherModels()
        {
            ObservableCollection<WeatherModelPhenomena> temp = new ObservableCollection<WeatherModelPhenomena>();

            foreach (var url in urls)
            {
                var req = httpClient.GetStringAsync(url.Value).Result;
                var colWeather = XDocument.Parse(req)
                                    .Descendants("MMWEATHER")
                                    .Descendants("REPORT")
                                    .Descendants("TOWN")
                                    .Descendants("FORECAST")
                                    .ToList();

                foreach (var FORECAST in colWeather)
                {
                    temp.Add(
                        new WeatherModelPhenomena()
                        {
                            CityName = url.Key,
                           
                            PHENOMENA = FORECAST.Element("PHENOMENA").Attribute("cloudiness").Value,
                            RELWET = FORECAST.Element("RELWET").Attribute("max").Value,
                        }
                        );
                }

            }

            return temp;
        }


    }
}