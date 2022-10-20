using AsciiString_UdemyDPAdditional_ConsoleApp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing.Ascii
{
    public class Ascii_Test
    {
        private string text = "testing!";
        [Fact]
        public void Test_ASCII()
        {
            var constructed = new str(text);
            Assert.Equal(text,constructed.ToString());

            str assigned = text;
            Assert.Equal(assigned.ToString(), text);
        }
        [Fact]
        public void ComparisonTest()
        {
            str first = text;
            str second = text;

            // Equals
            Assert.Equal(second, first);
            // operation ==
            Assert.True(first == second);
            // operation == with string
            Assert.Equal(text, second);
        }
        [Fact]
        public void ConcatenationTest()
        {
            str foo = "foo";
            str bar = "bar";
            Assert.Equal("foobar", foo + bar);
            Assert.Equal("foobar", "foo" + bar);
            Assert.Equal("foobar", foo + "bar");

            foo += bar;
            Assert.Equal("foobar", foo);
        }
    }
}
