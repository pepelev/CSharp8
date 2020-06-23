using System;
using NUnit.Framework;

namespace CSharp8
{
    public class StackallocInNestedExpressions
    {
        [Test]
        public void Test()
        {
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine($"Length: {numbers.Length}");
            var index = numbers.BinarySearch(5);
            Console.WriteLine($"Index of 5: {index}");
        }

        [Test]
        public unsafe void Test2()
        {
            int* a = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            var numbers = new Span<int>(a, 6);
        }
    }
}