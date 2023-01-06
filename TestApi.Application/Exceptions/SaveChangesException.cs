namespace TestApi.Domain.Exceptions
{
    public class SaveChangesException : Exception
    {
        public SaveChangesException(string name, object key) : base($"500|Cannot save Entity '{name}' ({key})")
        {
        }

        public SaveChangesException(Exception inner) : base($"500|Cannot save Entity", inner)
        {
        }
    }
}