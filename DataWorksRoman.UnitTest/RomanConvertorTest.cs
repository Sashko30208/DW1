using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomansToDecimalConverter;

namespace DataWorksRoman.UnitTest
{
    [TestClass]
    public class RomanConvertorTest
    {
        [TestMethod]
        public void CharToIntTest()
        {
            Converter converter = new Converter();
            char[] charArr = { 'I', 'V','X','L','C','D','M'};
                              //1,   5, 10, 50, 100,500,1000
            int[] expected = new int[7] { 1,2,3,4,5,6,7};
            int[] actual=new int[7];
            for(int i = charArr.Length-1;i>=0; )
            {
                actual[i] = converter.ToDec(charArr[i]);
                Assert.AreEqual(expected[i], actual[i]);
                i--;
            }
            //Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RomansToIntConverter() //check public int RomanToInt(string input)
        {
            Converter converter = new Converter();
            string Input = "MDCXLVII";//1647
            int expected = 1647;
            int actual = converter.RomanToInt(Input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutputTest()
        {
            Converter converter = new Converter();
            string InputOk = "MDCXLVII";//MDCXLVII=1647
            string InputEmpty = "";
            string InputWrongSymbols = "IIE";
            string InputWrongsequence = "VV";
            string expectedEmpty = "Incredible mistake. Oopsie Doopsie (Empty Input)";
            string expectedWrongSymbols = "Wrong input symbols";
            string expectedWrongSequence = "Incorrect sequence of numbers";
            string expected = "Value is: " + converter.RomanToInt(InputOk);


            string actualOk = converter.Output(InputOk);
            string actualEmpty = converter.Output(InputEmpty);
            string actualWS = converter.Output(InputWrongSymbols);
            string actualWrongSequence = converter.Output(InputWrongsequence);


            Assert.AreEqual(expected, actualOk);
            Assert.AreEqual(expectedEmpty, actualEmpty);
            Assert.AreEqual(expectedWrongSymbols, actualWS);
            Assert.AreEqual(expectedWrongSequence, actualWrongSequence);

        }
    }
}
