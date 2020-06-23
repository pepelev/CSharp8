using NUnit.Framework;

namespace CSharp8
{
    public class EnhancementOfInterpolatedVerbatimStrings
    {
        [Test]
        public void Test()
        {
            var value = 10;
            var a = $@"\{value}";
            var b = @$"\{value}";
        }
    }
}