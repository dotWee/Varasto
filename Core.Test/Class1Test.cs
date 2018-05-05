using System;
using Xunit;

namespace Varasto.Core.Test
{
    public class Class1Test
    {
        private readonly Class1 _class1;
        
        public Class1Test()
        {
            _class1 = new Class1();
        }
        
        [Fact]
        public void Test1()
        {
            int a = 1, b = 2;

            int expected = 3;
            int actual = _class1.Add(1, 2);
            
            Assert.Equal(expected, actual);
        }
    }
}
