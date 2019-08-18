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
        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            //它允许观察程序在提供程序完成发送通知前停止接收通知。
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }

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
