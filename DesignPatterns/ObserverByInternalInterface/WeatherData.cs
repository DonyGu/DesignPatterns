using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverByInternalInterface
{
    public struct WeatherData
    {
        private float temperature;
        private float humidity;
        private float pressure;

        public float Temperature { get => temperature; }
        public float Humidity { get => humidity; }
        public float Pressure { get => pressure; }

        public void SetMessureMents(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
        }
    }
   

}
