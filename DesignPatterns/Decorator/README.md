**装饰者模式**动态地将责任附加到对象上。若要拓展功能，装饰者提供了比继承更有弹性的替代方案。
## 1. 角色
+ 抽象构件（Component）角色：要包装的原始对象，是一个抽象类或接口。
+ 具体构件（ConcreteComponent）角色：最终要装饰的实际对象，是Component的实现类。
+ 装饰（Decorator）角色：是一个抽象类，继承自Component，同时持有一个对Component实例对象的引用。
+ 具体装饰（ConcreteComponent）角色：具体的装饰者对象，是Decorator的实现类，负责给ConcreteComponent附加责任。
## 2. Demo背景
+ 一个奶茶店每款奶茶可以自己选添加一些辅料如燕麦，布丁，红豆，珍珠等等。添加辅料不同可能价格也不同，又或者是我们全都要，同时添加多种辅料，这样我们设计对象时就遇到了困难，难道要排列组合去创建子类吗？这样做显然是不好的，类数量爆炸，设计死板。在这时候我们就可以引用装饰者模式，用组合的方式代替继承。
## 3. 代码实现
+ 抽象构件类（Component）：MilkyTea
```
public abstract class MilkyTea（奶茶）
    {
        public string description;
        public abstract double GetFee();
        //与java不一样，java父类方法不需要加关键词Virtual就可以在子类中重写
        public virtual string GetDescription()
        {
            return description;
        }
    }
```
+ 具体构建类（ConcreteComponent）：MilkGreenTea（奶绿）
```
public class MilkGreenTea : MilkyTea
    {
        public MilkGreenTea()
        {
            description = "Milk Green Tea";
        }
        public override double GetFee()
        {
            return 10;
        }
    }
```
+ 装饰类（Decorator）：CondimentDecorator(辅料)
```
public abstract class CondimentDecorator : MilkyTea
    {
        public MilkyTea milkyTea;
    }
```
+ 具体装饰（ConcreteComponent）：Oats（燕麦），Pudding（布丁）
```
    public class Oats : CondimentDecorator
    {
        public Oats(MilkyTea milkyTea)
        {
            this.milkyTea = milkyTea;
        }
        public override double GetFee()
        {
            return 1 + milkyTea.GetFee();
        }
        public override string GetDescription()
        {
            return milkyTea.GetDescription() + ",Oats";
        }
    }
    public class Pudding : CondimentDecorator
    {
        public Pudding(MilkyTea milkyTea)
        {
            this.milkyTea = milkyTea;
        }
        public override double GetFee()
        {
            return 3 + milkyTea.GetFee();
        }
        public override string GetDescription()
        {
            return milkyTea.GetDescription() + ",Pudding";
        }
    }
```
+ 测试代码与运行结果
```
static void Main(string[] args)
        {
            MilkyTea tea = new MilkGreenTea();
            Console.WriteLine($"{tea.GetDescription()}:￥{tea.GetFee()}。");
            tea = new Pudding(tea);
            Console.WriteLine($"{((Pudding)tea).GetDescription()}:￥{tea.GetFee()}。");
            tea = new Oats(tea);
            Console.WriteLine($"{tea.GetDescription()}:￥{tea.GetFee()}。");
        }
```
![运行结果](https://img2018.cnblogs.com/blog/1430055/201908/1430055-20190821234721607-1108946986.png)

## 4. 优缺点
+ 优点：为设计注入弹性。满足开闭原则，方便拓展。
+ 确点： 在设计中会加入大量小类。

## 5. 源码地址
[https://github.com/DonyGu/DesignPatterns](https://github.com/DonyGu/DesignPatterns)