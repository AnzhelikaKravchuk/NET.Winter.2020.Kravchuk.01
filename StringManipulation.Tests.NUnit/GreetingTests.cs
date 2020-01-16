using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StringManipulation.Tests.NUnit
{
    [TestFixture]
    public class GreetingTests
    {
        #region Variant with block-iterator yield
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData("John").Returns("Hello, John!");
                yield return new TestCaseData("Alex").Returns("Hello, Alex!");
                yield return new TestCaseData("").Returns("Hello, unknown!");
            }
        }

        [TestCaseSource(nameof(DataCases))]
        public string SayHello_HelloConcatUserNameWithYield(string userName)
        {
            Console.WriteLine("Debug info here.");
            return StringManipulation.Greeting.SayHello(userName);
        }

        #endregion

        #region Variant with test cases

        [TestCase("John", ExpectedResult = "Hello, John!")]
        [TestCase("Alex", ExpectedResult = "Hello, Alex!")]
        public string SayHello_HelloConcatWithConcreteUserName(string userName)
            => StringManipulation.Greeting.SayHello(userName);

        [TestCase("", ExpectedResult = "Hello, unknown!")]
        public string SayHello_HelloConcatWithEmptyString(string userName)
            => StringManipulation.Greeting.SayHello(userName);

        [Test]
        public void SayHello_StringIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => StringManipulation.Greeting.SayHello(null),
                message: "Method generates ArgumentNullException in case user name is null.");

        #endregion
    }
}