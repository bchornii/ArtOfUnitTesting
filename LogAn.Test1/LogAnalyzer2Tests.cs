using System;
using NUnit.Framework;

namespace LogAn.Test1
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
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
    }
}