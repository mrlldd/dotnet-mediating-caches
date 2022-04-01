namespace MediatingCaches.Exceptions;

public class MissingAssembliesException : MediatingCachesException
{
    public MissingAssembliesException() : base("Missing assemblies")
    {
    }
}