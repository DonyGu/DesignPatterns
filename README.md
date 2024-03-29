# 设计模式
## 1.  观察者模式
+  **观察者模式**定义了对象之间一个主题对多应多个观察者的依赖，这样一来，当一个对象改变状态时，它的所有依赖者都会收到通知并自动更新。
+ **角色：**
    + **主题（Subject）**：主题是一个接口，该接口规定了具体主题需要实现的方法
    + **观察者（Observer）**：观察者是一个接口，该接口规定了具体观察者用来更新数据的方法。
    + **具体主题（ConcreteSubject）**：具体主题是实现主题接口类的一个实例，该实例包含有可以经常发生变化的数据。具体主题使用一个集合，比如ArrayList，存放观察者的引用，以便数据变化时通知具体的观察者。
    + **具体观察者（Concrete Observer）**：具体观察者是实现观察者接口的一个实例。具体观察者包含有可以存放具体主题引用的主题接口变量，以便具体观察者让具体主题将自己添加到具体主题的集合中，使自己成为它的观察者，或让这个具体的主题将自己从具体的主题中的观察者列表中删除，使自己不再是它的观察者。
+ **一对多关系**：
    + 利用观察者模式，主题是具有状态的对象，并可以控制这些状态。也就是说，有“一个”具有状态的主题。另一方面，观察者使用这些状态，虽然这些状态并不属于他们。有许多的观察者，依赖主题来告诉他们状态何时改变了。这就产生一个关系：“一个”主题对应“多个”观察者的关系。
+ **优点**：
    + 具体主题和具体观察者是松耦合关系。由于主题（Subject）接口仅仅依赖于观察者（Observer）接口，因此具体主题只是知道它的观察者是实现观察者（Observer）接口的某个类的实例，但不需要知道具体是哪个类。同样，由于观察者仅仅依赖于主题（Subject）接口，因此具体观察者只是知道它依赖的主题是实现主题（subject）接口的某个类的实例，但不需要知道具体是哪个类。
    + 观察模式满足“开-闭原则”。主题（Subject）接口仅仅依赖于观察者（Observer）接口，这样，我们就可以让创建具体主题的类也仅仅是依赖于观察者（Observer）接口，因此如果增加新的实现观察者（Observer）接口的类，不必修改创建具体主题的类的代码。同样，创建具体观察者的类仅仅依赖于主题（Observer）接口，如果增加新的实现主题（Subject）接口的类，也不必修改创建具体观察者类的代码。
## 2. 装饰者模式
+ **装饰者模式**动态地将责任附加到对象上。若要拓展功能，装饰者提供了比继承更有弹性的方案。
+ **角色：**
    + 抽象构件（Component）角色：要包装的原始对象，是一个抽象类或接口。
    + 具体构件（ConcreteComponent）角色：最终要装饰的实际对象，是Component的实现类。
    + 装饰（Decorator）角色：是一个抽象类，继承自Component，同时持有一个对Component实例对象的引用。
    + 具体装饰（ConcreteComponent）角色：具体的装饰者对象，是Decorator的实现类，负责给ConcreteComponent附加责任。
+ 优点：为设计注入弹性。满足开闭原则，方便拓展。
+ 缺点： 在设计中会加入大量小类。


# 设计原则
1. **合成复用原则**：多用组合少用继承
3. **依赖倒转原则**：针对接口编程，不针对实现编程。
4. 为交互对象之间的松耦合设计而努力。
2. **开闭原则**：类应该对拓展开放，对修改关闭。
