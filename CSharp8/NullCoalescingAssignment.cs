using System;
using NUnit.Framework;

namespace CSharp8
{
    public class NullCoalescingAssignment
    {
        [Test]
        public void Test()
        {
            string a = null;

            Console.WriteLine(a ??= "A");
            Console.WriteLine(a);

            string value;
            value = a ??= "B";
            value = a ?? (a = "B");
        }
    }
}