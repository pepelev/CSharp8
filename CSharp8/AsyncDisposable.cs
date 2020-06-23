using System;
using System.Threading.Tasks;
using NUnit.Framework;

//#if NET472 || NET48

//namespace System
//{
//    public interface IAsyncDisposable
//    {
//        ValueTask DisposeAsync();
//    }
//}

//#endif

namespace CSharp8
{
    public class AsyncDisposable : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Delay(3_000).ConfigureAwait(false);
            Console.WriteLine("Dispose completed");
        }
    }

    public sealed class AsyncDisposableTest
    {
        [Test]
        public async Task Test()
        {
            await using (new AsyncDisposable())
            {
                Console.WriteLine("Inside await using");
            }
        }
    }
}