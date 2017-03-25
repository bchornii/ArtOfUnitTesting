using System;

namespace LogAn
{
    public class LogAnalyzer2
    {
        public IWebService Service { get; set; }
        public IEmailService Email { get; set; }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("Filename too short:" + fileName);
                }
                catch (Exception e)
                {
                    Email.SendEmail("a", "subject", e.Message);
                }
            }
        }
    }
}