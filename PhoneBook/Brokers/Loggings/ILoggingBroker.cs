namespace PhoneBook.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string message);
    }
}
