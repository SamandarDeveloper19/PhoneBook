namespace PhoneBook.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        public void LogInformation(string message) =>
            Console.WriteLine(message);

        public void LogError(string message) =>
            Console.WriteLine(message);
    }
}
