using System;
using NUnit.Framework;

namespace CSharp8
{
    public class UnmanagedConstructedTypes
    {
        private struct MyStruct<T>
        {
            private T a;
        }

        [Test]
        public void Test()
        {
            Do(new MyStruct<int>());
        }

        private static void Do<T>(T a) where T : unmanaged
        {
            Console.WriteLine(a);
        }
    }
}