# 通过C#的内置观察者接口实现观察者模式
**##1. 接口介绍**

C#内部提供了IObservable<T>和IObserver<T>两个泛型接口，IObservable是可观察的，就是主题（Subject）要实现的接口，IObserver就是观察者需要实现的接口，接口定义如下：
```
//T:提供通知信息的对象。
public interface IObservable<out T>
{
    //通知提供程序观察程序将接收通知。
    IDisposable Subscribe(IObserver<T> observer);
}
```
```
//T:提供通知信息的对象。
public interface IObserver<in T>
{
    //通知观察者提供程序已完成发送基于推送的通知。
    void OnCompleted();
    //通知观察者提供程序遇到错误情况。
    void OnError(Exception error);
    //向观察者提供新数据。
    void OnNext(T value);
}
```
**2. Demo背景**

这里与[上一篇](https://www.cnblogs.com/donyblog/p/11370690.html)一致：设计一个气象观测站，测量温度、湿度、气压等，会有多种公告板如气温布告板，舒适度布告板，天气预报布告板等等。每当天气数据变化时，这些布告板的数据就需要相应自动更新。
**3. 代码设计**
+ 首先建一个WeatherData，这是主题向观察者传递的数据。
```
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
```
+ 新建WeatherDataProvider类作为主题的提供方，提供订阅与取消订阅的方法。
```
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
```
+ 观察者Display类实现
```
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
```
+ 测试代码与运行效果
```
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
```

