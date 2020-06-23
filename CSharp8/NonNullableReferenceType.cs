using System;
using System.Collections.Generic;
using NUnit.Framework;

#nullable enable

namespace CSharp8
{

    public class NonNullableReferenceType
    {
        public NonNullableReferenceType()
        {
            A = "A";
        }

        public NonNullableReferenceType(int a)
        {
        }

        public string A { get; set; } /*= default!*/
    }


    public class NonNullableReferenceTypeTest
    {
        [Test]
        public void Test(string? a)
        {
            var obj = new NonNullableReferenceType();
            obj.A = a?.Length.ToString();
        }

        private string Do(string a)
        {
            //var type = Type.GetType(a);
            //return type.Name;

            var dictionary = new Dictionary<string, string>
            {
                {"1", "2"}
            };
            if (dictionary.TryGetValue(a, out var result))
            {
                return result;
            }

            return result;
        }
    }
}

#nullable restore