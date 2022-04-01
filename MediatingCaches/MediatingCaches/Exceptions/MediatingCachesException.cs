namespace MediatingCaches.Exceptions;

public abstract class MediatingCachesException : Exception
{
    protected MediatingCachesException(string message): base(message)
    {
    }
}