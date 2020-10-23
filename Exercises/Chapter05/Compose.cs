using System;

namespace Exercises.Chapter05
{
    using static Console;

    public static class ComposeExt
    {
        public static Func<T1, R> Compose<T1, T2, R>(this Func<T2, R> f1, Func<T1, T2> f2) =>
            x => f1(f2(x));
    }

    public static class Exercises
    {
        public static void Run()
        {
            Func<int, int> AddTwoTo = x => x + 2;
            Func<int, int> AddFourTo = x => x + 4;

            var composedFunc = AddTwoTo.Compose(AddFourTo);
            WriteLine(composedFunc(2));
        }

        public static int AddTwoTo(int x) => x + 2;
    }
}
