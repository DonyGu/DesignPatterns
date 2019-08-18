using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class MilkyTea
    {
        public string description;
        public abstract double GetFee();
        //与java不一样，java父类方法不需要加关键词Virtual就可以在子类中重写
        public virtual string GetDescription()
        {
            return description;
        }
        
    }
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
}
