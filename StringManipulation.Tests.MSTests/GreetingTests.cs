using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest
//https://www.meziantou.net/mstest-v2-setup-a-test-project-and-run-tests.htm

namespace StringManipulation.Tests.MSTests
{
    [TestClass]
    public class GreetingTests
    {
        #region Pattern AAA
        
        [TestMethod]
        public void SayHello_HelloConcatWithAlex_ReturnHelloAlex()
        {
            string userName = "Alex";

            string expected = "Hello, Alex!";

            string actual = Greeting.SayHello(userName);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SayHello_HelloConcatWithJohn_ReturnHelloJohn()
        {
            string userName = "John";

            string expected = "Hello, John!";

            string actual = Greeting.SayHello(userName);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SayHello_HelloConcatWithEmptyString_Return_HelloUnknown()
        {
            string userName = string.Empty;

            string expected = "Hello, unknown!";

            string actual = Greeting.SayHello(userName);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Variant with test cases

        [DataTestMethod]
        [DataRow("John", "Hello, John!")]
        [DataRow("Alex", "Hello, Alex!")]
        [DataRow("", "Hello, unknown!")]
        public void SayHello_HelloConcatWithConcreteUserNameOrEmpty(string userName, string expected)
        {
            string actual = Greeting.SayHello(userName);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Variant with block-iterator yield as property

        private static IEnumerable<string[]> DataCasesAsProperty
        {
            get
            {
                yield return new[] {"John", "Hello, John!"};
                yield return new[] {"Alex", "Hello, Alex!"};
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(DataCasesAsProperty), DynamicDataSourceType.Property)]
        public void SayHelloSuccessfulTests(string userName, string expected)
        {
            string actual = Greeting.SayHello(userName);

            Assert.AreEqual(expected, actual);
        }

        #endregion
        
        #region Variant with block-iterator yield as method
        
        private static IEnumerable<string[]> DataCasesAsMethod()
        {
            yield return new[] {"John", "Hello, John!"};
            yield return new[] {"Alex", "Hello, Alex!"};
        }


        [DataTestMethod]
        [DynamicData(nameof(DataCasesAsProperty), DynamicDataSourceType.Property)]
        public void SayHelloSuccessfulTests_(string userName, string expected)
        {
            string actual = Greeting.SayHello(userName);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test Exception Case

        [TestMethod]
        public void SayHello_HelloConcatWithNull_Throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Greeting.SayHello(null),
                message: "Method generates ArgumentNullException in case user name is null");
        }

        #endregion
    }
}