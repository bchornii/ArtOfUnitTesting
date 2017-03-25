using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LogAn.Test1
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [SetUp]
        public void Setup()
        {
            //_logAnalyzer = new LogAnalyzer();
        }

        [Test]
        [Category("Fast Tests")]
        public void IsValidFileName_validFile_ReturnsTrue()
        {           
            // arrange 
            var analizer = new LogAnalyzer();

            // act
            var result = analizer.IsValidLogFileName("whatever.SLF");

            // assert
            Assert.IsTrue(result, "filename should be valid");
        }

        /*
         * Notice how the assert is performed against the mock object, 
         * and not against the LogAnalyzer class. 
         * That’s because we’re testing the interaction between LogAnalyzer and the web service. 
         */
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            // arrange
            var mockServise = new MockWebService();
            var analizer = new LogAnalyzer(mockServise);
            const string fileName = "abc.ext";

            // act
            analizer.Analize(fileName);

            // assert
            Assert.AreEqual("File name too short : abc.ext", mockServise.LastError);
        }

        [Test]
        [Category("Slow Tests")]
        [ExpectedException(typeof(ArgumentException), "No filename provided!")]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            // arrange
            var analizer = new LogAnalyzer();

            // act
            analizer.IsValidLogFileName(string.Empty);
        }

        [TearDown]
        public void TearDown()
        {
            //_logAnalyzer = null;
        }
    }
}
