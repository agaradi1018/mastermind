using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMind;

namespace MasterMind.UnitTests
{
    [TestClass]
    public class MasterMindProjTests
    {
        MasterMindProj proj;

        [TestInitialize]
        public void before()
        {
            proj = new MasterMindProj();
        }

        [TestMethod]
        public void generateSecretNumber_returnTrue()
        {
            string result = proj.generateSecretNumber();
            Assert.IsTrue(result.Length == 4);
        }

        [TestMethod]
        public void validateInput_4digits_returnTrue()
        {
            bool result = proj.validateInput("1234");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void validateInput_outOfRangeInput_returnFalse()
        {
            bool outOfRangeInt = proj.validateInput("7889");
            bool outOfRangeChars = proj.validateInput("12c34");
            Assert.IsFalse(outOfRangeInt);
            Assert.IsFalse(outOfRangeChars);
        }

        [TestMethod]
        public void validateInput_lessThan4digits_returnFalse()
        {
            bool result = proj.validateInput("124");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void validateInput_greaterThan4digits_returnFalse()
        {
            bool result = proj.validateInput("12425");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void compare_matchSecretAndGuess_returnTrue()
        {
            proj.freq = new System.Collections.Generic.List<string>(){ "1","2","4"};
            char[] preResult = { '+', '+', '+', '+' };
            char[] result = proj.compare("1224", "1224");
            CollectionAssert.AreEqual(result, preResult);
        }

        [TestMethod]
        public void compare_noMatchSecretAndGuess_returnFalse()
        {
            proj.freq = new System.Collections.Generic.List<string>() { "1", "2", "4" };
            char[] preResult = { '+', '+', '+', '+' };
            char[] result = proj.compare("1224", "1234");
            CollectionAssert.AreNotEqual(result, preResult);
        }
    }
}
