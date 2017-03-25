using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private readonly IWebService _webService;

        public LogAnalyzer() { }

        public LogAnalyzer(IWebService webService)
        {
            _webService = webService;
        }

        public void Analize(string fileName)
        {
            if (fileName.Length < 8)
            {
                _webService.LogError($"File name too short : {fileName}");
            }
        }

        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filename provided!");
            }

            if (!fileName.EndsWith(".SLF"))
            {
                return false;
            }
            return true;
        }
    }
}
