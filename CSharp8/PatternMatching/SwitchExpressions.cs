using System;
using NUnit.Framework;

namespace CSharp8.PatternMatching
{
    public class SwitchExpressions
    {
        public enum Color
        {
            Red,
            Blue,
            Yellow,
            Green,
            Orange,
            Pink
        }

        public enum Цвет : byte
        {
            Красный = 1 << 0,
            Синий = 1 << 1,
            Желтый = 1 << 2,
            Зеленый = 1 << 3,
            Оранжевый = 1 << 4,
            Розовый = 1 << 5
        }

        private Цвет Before(Color system)
        {
            switch (system)
            {
                case Color.Red:
                    return Цвет.Красный;
                case Color.Blue:
                    return Цвет.Синий;
                case Color.Yellow:
                    return Цвет.Желтый;
                case Color.Green:
                    return Цвет.Зеленый;
                case Color.Orange:
                    return Цвет.Оранжевый;
                case Color.Pink:
                    return Цвет.Розовый;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }

        private Цвет After(Color system)
        {
            var result = system switch
            {
                Color.Red => Цвет.Красный,
                Color.Blue => Цвет.Синий,
                Color.Yellow => Цвет.Желтый,
                Color.Green => Цвет.Зеленый,
                Color.Orange => Цвет.Оранжевый,
                Color.Pink => Цвет.Розовый,
                _ => throw new ArgumentOutOfRangeException(nameof(system), system, null)
            };

            return result;
        }

        private Цвет AfterWithoutDefault(Color system)
        {
            var result = system switch
            {
                Color.Red => Цвет.Красный,
                Color.Blue => Цвет.Синий,
                Color.Yellow => Цвет.Желтый,
                Color.Green => Цвет.Зеленый,
                Color.Orange => Цвет.Оранжевый,
                Color.Pink => Цвет.Розовый
            };

            return result;
        }

        [Test]
        public void BeforeTest([Values] Color system)
        {
            var result = Before(system);
            Console.WriteLine(result);
        }

        [Test]
        public void AfterTest([Values] Color system)
        {
            var result = After(system);
            Console.WriteLine(result);
        }

        [Test]
        public void AfterWithoutDefaultTest([Values(1,2,3,10)] Color system)
        {
            var result = AfterWithoutDefault(system);
            Console.WriteLine(result);
        }
    }
}