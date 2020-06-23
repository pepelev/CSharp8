using System;
using NUnit.Framework;

namespace CSharp8
{
    // works only on .net core
#if !(NET472 || NET48)

    public interface ISomething
    {
        string Name { get; }

        string Greeting => $"Hello {Name}";
    }

    public class DefaultInterfaceImplementation
    {
        [Test]
        public void METHOD()
        {
            var something = new Something();
            //var greeting = something.Greeting();
            //Console.WriteLine(greeting);
        }

        private sealed class Something : ISomething
        {
            public string Name => "Bob";
        }
    }

    public static class Extensions
    {
        public static string Greeting(this ISomething something)
        {
            return $"Hello {something.Name}";
        }
    }

#endif
}