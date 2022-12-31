namespace TestApi.Domain.Exceptions;

public class TooMuchLayerException : Exception
{
    public TooMuchLayerException(string name, object key) : base($"413|Entity '{name}' ({key}) has so much layers.")
    {
    }
}
