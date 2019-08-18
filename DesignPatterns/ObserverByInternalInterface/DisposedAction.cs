using System;

namespace ObserverByInternalInterface
{
    internal class DisposedAction : IDisposable
    {
        private Func<object> p;

        public DisposedAction(Func<object> p)
        {
            this.p = p;
        }
        public void Dispose()
        {
            p();
        }
    }
}