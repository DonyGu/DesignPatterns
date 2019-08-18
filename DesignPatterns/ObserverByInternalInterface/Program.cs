using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverByInternalInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weather = new WeatherData();
            WeatherDataProvider provider = new WeatherDataProvider();
            Display display1 = new Display("布告板1");
            Display display2 = new Display("布告板2");
            Console.WriteLine("---------加入布告板1---------");
            display1.Subscribe(provider);
            weather.SetMessureMents(20,20,20);
            provider.SendWeatherData(weather);
            Console.WriteLine("---------加入布告板2---------");
            display2.Subscribe(provider);
            weather.SetMessureMents(30, 30, 30);
            provider.SendWeatherData(weather);
            Console.WriteLine("----------取消布告板1----------");
            display1.Unsubscribe();
            weather.SetMessureMents(23, 23, 23);
            provider.SendWeatherData(weather);
            Console.WriteLine("运行结束");
            Console.ReadLine();
        }
    }
}
