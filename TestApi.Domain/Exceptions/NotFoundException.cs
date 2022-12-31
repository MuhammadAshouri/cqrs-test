namespace TestApi.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($@"404|Entity '{name}' ({key}) was not found.")
        {
        }
    }
}
