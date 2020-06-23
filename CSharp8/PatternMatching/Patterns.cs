using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp8.PatternMatching
{
    public class Patterns
    {
        [Test]
        public void Tuples()
        {
            var description = (1, "abc") switch
            {
                (1, "ab") => "starts with one and ends with 'ab'",
                (1, "abc") => "starts with one",
                (1, string str) when str.Length < 30 => $"ends with '{str}' and shorter than 30 chars",
                (1, string str) => $"ends with '{str}'",
                _ => throw new ArgumentOutOfRangeException()
            };
            Console.WriteLine(description);
        }

        [Test]
        public void Properties()
        {
            var description1 = new Version(3, 12, 4) switch
            {
                { } => "not null",
                null => "null"
            };

            var description2 = new Version(3, 12, 4) switch
            {
                { Major: 2 } => "old",
                { Major: 3, Minor: 12 } => "LTS",
                { Major: 3, Minor: 13 } => "pre-release",
                { Major: int m} => $"unknown Major {m}",

                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [Test]
        public void PositionalPatterns()
        {
            var description = new KeyValuePair<int, string>(10, "hello") switch
            {
                (10, _) => "ten",
                (_, "hello") => "hello",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public class MyClass
        {
            public MyClass(Version version, KeyValuePair<int, Version> pair)
            {
                Version = version;
                Pair = pair;
            }

            public Version Version { get; }
            public KeyValuePair<int, Version> Pair { get; }
        }

        [Test]
        public void Recursive()
        {
            var myClass = new MyClass(
                new Version(10, 12),
                new KeyValuePair<int, Version>(100, new Version(12, 4))
            );

            var description = myClass switch
            {
                { Version: {Major:10, Minor:12}, Pair: (100, {Major:12, Minor:4}) } => "good",
                _ => "bad"
            };
        }
    }

    #region framework

#if NET472 || NET48

    public static class PairExtensions
    {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value)
        {
            (key, value) = (pair.Key, pair.Value);
        }
    }

#endif

    #endregion
}