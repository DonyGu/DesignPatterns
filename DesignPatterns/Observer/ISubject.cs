using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObserver();
    }
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }
    public interface IDisplayElement
    {
        void Display();
    }
}
