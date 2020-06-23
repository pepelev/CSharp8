using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp8
{
    public class IndexAndRange
    {
        [Test]
        public void Index()
        {
            var last = new List<int> {10, 15}[^1];
            Console.WriteLine(last);
        }

        [Test]
        public void IndexOfAnyIndexedType()
        {
            var last = new MyList(1,2,34)[^1];
            Console.WriteLine(last);
        }

        [Test]
        public void Range()
        {
            var array = new[] {1,2,3,4,5,6};
            var tail = array[2..];
            tail.Should().Equal(3, 4, 5, 6);
        }

        [Test]
        public void Ranges()
        {
            var ranges = new[]
            {
                0..4,
                ..,
                1..,
                ..^1,
                1..2,
                ^2..3
            };

            var array = new[] {1, 2, 3, 4};
            foreach (var range in ranges)
            {
                var subArray = array[range];
                Console.WriteLine($"{range} {string.Join(", ", subArray)}");
            }
        }

        private sealed class MyList : IReadOnlyList<int>
        {
            private readonly List<int> list;

            public MyList(params int[] list)
            {
                this.list = new List<int>(list);
            }

            public IEnumerator<int> GetEnumerator() => list.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) list).GetEnumerator();

            public int Count => list.Count;
            public int this[int index] => list[index];
        }
    }
}