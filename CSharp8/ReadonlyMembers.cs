using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp8
{
    public class ReadonlyMembers
    {
        private struct StructWithMutableList
        {
            private readonly List<int> content;

            public StructWithMutableList(List<int> content)
            {
                this.content = content;
            }

            public readonly void Append(int item)
            {
                content.Add(item);
            }
        }

        private struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; private set; }
            public int Y { get; private set; }

            public double DistanceByX
            {
                get
                {
                    Y = 0;
                    return Math.Sqrt(X * X + Y * Y);
                }
            }

            public override readonly string ToString()
            {
                return $"({X}, {Y}) distance by x: {DistanceByX}";
            }

            // won't compile
            //public readonly void Translate(int xOffset, int yOffset)
            //{
            //    X += xOffset;
            //    Y += yOffset;
            //}
        }

        [Test]
        public void Defensive_Copy()
        {
            var point = new Point(10, 20);
            Console.WriteLine(point.ToString());
            point.Y.Should().Be(20);
        }
    }
}