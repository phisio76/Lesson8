using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherModelPhenomena
    {
        int p1, p2;

        public string RELWET { get { return $"Влажность воздуха { p1.ToString()} %"; } set { int.TryParse(value, out p1); } }
        public string PHENOMENA { get { return $"Облачность { p2.ToString()} (-1 - туман, 0 - ясно, 1 - малооблачно, 2 - облачно, 3 - пасмурно)"; } set { int.TryParse(value, out p2); } }
        

        public string CityName { get; internal set; }
    }
}