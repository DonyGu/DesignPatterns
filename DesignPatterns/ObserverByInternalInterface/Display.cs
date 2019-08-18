using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverByInternalInterface
{
    public class Display : IObserver<WeatherData>
    {
        private IDisposable unsubscriber;
        private string displayName;

        public Display(string name)
        {
            this.displayName = name;
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            if (provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
        //通知观察者提供程序已完成发送基于推送的通知。
        public void OnCompleted()
        {
            Console.WriteLine($"{displayName}天气数据发送完毕");
        }
        //通知观察者提供程序遇到错误情况。
        public void OnError(Exception error)
        {
            Console.WriteLine($"在提供天气数据时，发生错误。");
        }
        //向观察者提供新数据。
        public void OnNext(WeatherData value)
        {
            Console.WriteLine($"{displayName}当前天气 => 温度：{value.Temperature}, 湿度：{value.Humidity}, 气压{value.Pressure}。 ");
        }
    }
}
