using System;
using NUnit.Framework;

namespace LogAn.Test1
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        [Category("Logic Tests")]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            // arrange
            var stubService = new StubService
            {
                ToThrow = new Exception("fake exception")
            
            };
            var mockEmail = new MockEmailService();
            var log = new LogAnalyzer2
            {
                Service = stubService,
                Email = mockEmail
            };        
            const string tooShortFileName = "abc.ext";

            // act
            log.Analyze(tooShortFileName);

            // assert
            Assert.AreEqual("a", mockEmail.To);
            Assert.AreEqual("fake exception", mockEmail.Body);
            Assert.AreEqual("subject", mockEmail.Subject);
        }

        [Test]
        [Category("Logic Tests")]
        public void Analyze_EmptyMessage_WebServiceGetMessage()
        {
            // arrange
            var mockWs = new MockWebService();
            var analyzer = new LogAnalyzer2 {Email = null, Service = mockWs};
            const string tooShortFileName = "abc.ext";

            // act
            analyzer.Analyze(tooShortFileName);

            // assert
            Assert.AreEqual("Filename too short:abc.ext", mockWs.LastError);
        }
    }
}