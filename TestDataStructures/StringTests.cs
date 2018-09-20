using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace TestDataStructures
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestUnicodeChars()
        {
            string input = "\uD834\uDD61";
            for (var i = 0; i < input.Length; i += char.IsSurrogatePair(input, i) ? 2 : 1)
            {
                var codepoint = char.ConvertToUtf32(input, i);
                Console.WriteLine("U+{0:X4}", codepoint);
            }
        }

        [TestMethod]
        public void TestFindFirstUniqueCharUnicode()
        {
            string input = "\uD834\uDD61";
            input = input + "some ascii values" + input;
            var result = StringMan.FindFirstUniqueChar(input);
            Assert.IsTrue(result == "o", "First unique char should have been 'o'. Actual= {0}", result);
        }

        [TestMethod]
        public void TestReverseStringAscii()
        {
            var result = StringMan.ReverseString("Hello World in jungle.");
            Console.WriteLine(result);
            result = StringMan.ReverseString("Hello   World in  jungle.  ");
            Console.WriteLine(result);
            result = StringMan.ReverseString("Hello \uD834\uDD61World jungle.");
            Console.WriteLine(result);
            result = StringMan.ReverseString(" Hello jungle. ");
            Console.WriteLine(result);
            result = StringMan.ReverseString("   Hello      in    jungle.  ");
            Console.WriteLine(result);
        }

        [TestMethod]
        public void FindLongestPalindromTest()
        {
            string input = "abacabacabbacdca";
            Console.WriteLine("input={0}", input);
            var result = StringMan.FindLongestPelindromeON(input);
            Console.WriteLine("Longest palindrom found = {1}", result);

        }

        [TestMethod]
        public void IsomorphicStringTest()
        {
            Assert.IsTrue(StringMan.IsIsomorphic("egg", "add"), "'egg' and 'add' are isomorphic.");
            Assert.IsFalse(StringMan.IsIsomorphic("foo", "bar"), "'foo' and 'bar' not isomorphic.");
            Assert.IsTrue(StringMan.IsIsomorphic("paper", "title"), "'paper' and 'title' are isomorphic.");
            Assert.IsFalse(StringMan.IsIsomorphic("ab", "aa"), "'foo' and 'bar' not isomorphic.");


            Assert.IsFalse(StringMan.IsIsomorphic("foo", "adds"), "'foo' and 'adds' not isomorphic.");
            Assert.IsFalse(StringMan.IsIsomorphic("foo", null), "'foo' and null not isomorphic.");
            Assert.IsTrue(StringMan.IsIsomorphic(null, null), "null and null are isomorphic.");
        }
    }
}
