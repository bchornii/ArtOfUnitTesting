using System;
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
        [Category("Logic Tests")]
        public void IsValidFileName_validFile_ReturnsTrue()
        {           
            // arrange 
            var analizer = new LogAnalyzer();

            // act
            var result = analizer.IsValidLogFileName("whatever.SLF");

            // assert
            Assert.IsTrue(result, "filename should be valid");
        }

        [Test]
        [Category("Exception Tests")]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            // arrange
            var analizer = new LogAnalyzer();

            // assert
            Assert.Throws<ArgumentException>(() => analizer.IsValidLogFileName(string.Empty));
        }

        /*
         * Notice how the assert is performed against the mock object, 
         * and not against the LogAnalyzer class. 
         * That’s because we’re testing the interaction between LogAnalyzer and the web service. 
         */
        [Test]
        [Category("Logic Tests")]
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

        /*
         * The same test as previous one but with dynamic mocks
         */
        //[Test]
        //public void Analyze_TooShortFileName_CallsWebService()
        //{
        //    // arrange
        //    var mocks = new MockRepository();
        //    var simulatedWebService = mocks.StrictMock<IWebService>();

        //    using (mocks.Record())
        //    {
        //        simulatedWebService.LogError("File name too short : abc.ext"); // set expectation
        //    }

        //    var analizer = new LogAnalyzer(simulatedWebService);
        //    const string fileName = "abc.ext";

        //    analizer.Analize(fileName);

        //    mocks.Verify(simulatedWebService); // assert expectations
        //}

        [TearDown]
        public void TearDown()
        {
            //_logAnalyzer = null;
        }
    }
}
