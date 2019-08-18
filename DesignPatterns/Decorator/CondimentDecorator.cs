using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class CondimentDecorator : MilkyTea
    {
    }
    public class Oats : CondimentDecorator
    {
        MilkyTea milkyTea;
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
        MilkyTea milkyTea;
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
}
