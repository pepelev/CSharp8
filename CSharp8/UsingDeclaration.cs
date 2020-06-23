using System;
using NUnit.Framework;

namespace CSharp8
{
    public class UsingDeclaration
    {
        private sealed class File : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("File disposed");
            }
        }

        [Test]
        public void Test()
        {
            using var file = new File();
            
            //var file2 = new File();
            //using file2; // won't compile
        }
    }
}