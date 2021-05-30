// Павлов Дмитрий.
//3. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не
//создана база данных, обращение к несуществующему вопросу, открытие слишком большого
//файла и т.д.).
//б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив
//другие «косметические» улучшения на свое усмотрение.
//в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия,
//авторские права и др.).
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
    class DataProvider
    {
        //static string[] urls;
        static Dictionary<string, string> urls; 
        static DataProvider()
        {
            urls = new Dictionary<string, string>();

            urls.Add("Москва", @"https://xml.meteoservice.ru/export/gismeteo/point/32277.xml");
            urls.Add("Белгород", @"https://xml.meteoservice.ru/export/gismeteo/point/112.xml");
        }

        HttpClient httpClient;

        public DataProvider()
        {
            httpClient = new HttpClient();
        }
        public ObservableCollection<WeatherModel> GetWetherModels()
        {
            ObservableCollection<WeatherModel> temp = new ObservableCollection<WeatherModel>();

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
                        new WeatherModel()
                        {
                            CityName = url.Key,
                            PRESSURE = FORECAST.Element("PRESSURE").Attribute("max").Value,
                            TEMPERATURE = FORECAST.Element("TEMPERATURE").Attribute("max").Value,
                            WIND = FORECAST.Element("WIND").Attribute("max").Value,
                        }
                        );
                }
                
            }

            return temp;
        }

    }
}
