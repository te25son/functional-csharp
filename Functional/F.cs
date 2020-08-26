using System;

namespace Functional
{
    public static class F
    {
        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> func)
            where TDisp : IDisposable
        {
            using (disposable) return func(disposable);
        }
    }
}
