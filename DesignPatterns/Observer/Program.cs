using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            Console.WriteLine("--------公告板1加入观察者-------");
            CurrentConditionDisplay display1 = new CurrentConditionDisplay(weatherData);
            weatherData.SetMessureMents(10, 20, 30);
            Console.WriteLine("--------公告板2加入观察者-------");
            ForecastDisplay display2 = new ForecastDisplay(weatherData);
            weatherData.SetMessureMents(15, 25, 35);
            Console.WriteLine("--------公告板1退出观察者-------");
            weatherData.RemoveObserver(display1);
            weatherData.SetMessureMents(19, 29, 39);
        }
    }
}
