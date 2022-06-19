namespace LoggingApi.Domain.Values
{
    public class LogException
    {
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public LogException()
        {

        }
        public LogException(string message, string stacktrace)
        {
            Message = message;
            Stacktrace = stacktrace;
        }
    }
}
