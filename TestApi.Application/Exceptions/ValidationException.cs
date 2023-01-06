namespace TestApi.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base($"400|{message}")
        {
        }
    }
}