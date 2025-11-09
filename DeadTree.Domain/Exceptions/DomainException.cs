public class DomainException : Exception
{
    public string ErrorCode { get; }
    public object[] ErrorArgs { get; }

    public DomainException(string errorCode, params object[] errorArgs)
        : base($"{errorCode}")
    {
        ErrorCode = errorCode ?? throw new ArgumentNullException(nameof(errorCode));
        ErrorArgs = errorArgs ?? [];
    }
}