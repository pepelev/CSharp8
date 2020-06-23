using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp8
{
    public class AsyncStream : IAsyncEnumerable<int>
    {
        public async IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken token = default)
        {
            yield return 10;
            await Task.Delay(1.Seconds(), token).ConfigureAwait(false);
            yield return 20;
            await Task.Delay(3.Seconds(), token).ConfigureAwait(false);
            yield return 30;
        }
    }

    public class AsyncStreamTest
    {
        [Test]
        public async Task Test()
        {
            await foreach (var number in new AsyncStream())
            {
                Console.WriteLine($"Time: {DateTime.Now}, Number: {number}");
            }
        }

        [Test]
        public async Task WithCancellation()
        {
            using var tokenSource = new CancellationTokenSource(2.Seconds());
            await foreach (var number in new AsyncStream().WithCancellation(tokenSource.Token))
            {
                Console.WriteLine($"Time: {DateTime.Now}, Number: {number}");
            }
        }

        [Test]
        public async Task Linq()
        {
            List<string> strings = await new AsyncStream()
                .Where(x => x % 2 == 0)
                .SelectAwait(
                    async count =>
                    {
                        await Task.Delay(1.Seconds()).ConfigureAwait(false);
                        return new string('a', count);
                    }
                )
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}