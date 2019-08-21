using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class CondimentDecorator : MilkyTea
    {
        public MilkyTea milkyTea;
    }
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
}
