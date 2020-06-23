using System;
using NUnit.Framework;

namespace CSharp8
{
    public class StaticLocalFunctions
    {
        [Test]
        public void METHOD()
        {
            int a = 10, b = 20;
            Do();

            /*static*/ void Do()
            {
                a++;
                Console.WriteLine($"{a}, {b}");
            }
        }
    }
}