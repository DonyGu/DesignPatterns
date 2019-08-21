using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            MilkyTea tea = new MilkGreenTea();
            Console.WriteLine($"{tea.GetDescription()}:￥{tea.GetFee()}。");
            tea = new Pudding(tea);
            Console.WriteLine($"{((Pudding)tea).GetDescription()}:￥{tea.GetFee()}。");
            tea = new Oats(tea);
            Console.WriteLine($"{tea.GetDescription()}:￥{tea.GetFee()}。");
        }
    }
}
