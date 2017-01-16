using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RNGTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void UserInputTest()
        {
            int input = 59;
            int numberGuess = Int16.Parse(Convert.ToString(input));
        }
    }
}
