using System;
using NUnit.Framework;

namespace CSharp8
{
    public class DisposableRefStruct
    {
        private ref struct RefStruct /*: IDisposable*/
        {
            public void Dispose()
            {
                Console.WriteLine("Disposed");
            }
        }

        [Test]
        public void METHOD()
        {
            using (var obj = new RefStruct())
            {
                
            }
        }
    }
}