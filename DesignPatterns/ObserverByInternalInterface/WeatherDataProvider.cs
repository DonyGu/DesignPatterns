using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverByInternalInterface
{
    public class WeatherDataProvider : IObservable<WeatherData>
    {
        //观察者列表
        private List<IObserver<WeatherData>> observers;
        public WeatherDataProvider()
        {
            observers = new List<IObserver<WeatherData>>();
        }
        //定义一个可销毁的内部类，所以继承自IDisposable接口
        //观察者注册时生成对象，注销时，调用Dispose()，取消订阅并释放资源
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<WeatherData>> _observers;
            private IObserver<WeatherData> _observer;

            public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }
            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }

        //通知提供程序观察程序将接收通知。
        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            //返回可销毁的内部类，当观察者取消订阅时，调用该类的Dispose(),释放资源
            return new Unsubscriber(observers, observer);
        }
        //通知所有观察者更新数据数据
        public void SendWeatherData(Nullable<WeatherData> weather)
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
                observer.OnNext(weather.Value);
            }
        }
    }
}
