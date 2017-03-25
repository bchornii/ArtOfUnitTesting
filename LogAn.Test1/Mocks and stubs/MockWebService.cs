namespace LogAn.Test1
{
    public class MockWebService : IWebService
    {
        public string LastError { get; set; }

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}