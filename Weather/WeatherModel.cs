using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherModel
    {
        int t,p,w;

        public string TEMPERATURE { get { return $"{ t.ToString()} °C"; } set { int.TryParse(value, out t); } }
        public string PRESSURE { get { return $"{ p.ToString()} мм.рт.ст."; } set { int.TryParse(value, out p); } }
        public string WIND { get { return $"{ w.ToString()} м/сек"; } set { int.TryParse(value, out w); } }

        public string CityName { get; internal set; }        
    }
}
