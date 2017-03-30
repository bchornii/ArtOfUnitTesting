namespace LogAn.Test1
{
    public class MockEmailService : IEmailService
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}