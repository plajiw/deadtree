using DeadTree.Domain.Constants;

namespace DeadTree.Domain.ValueObjects;
public record class Username
{
    private const int MinLength = 3;
    private const int MaxLength = 30;
    private string Value { get; init; }

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException(ErrorCodes.UsernameRequired);
        if (value.Length is < MinLength or > MaxLength)
            throw new DomainException(ErrorCodes.UsernameLength, MinLength, MaxLength);
        if (!RegexPatterns.Alphanumeric().IsMatch(value))
            throw new DomainException(ErrorCodes.UsernameAlphanumeric);
        
        Value = value;
    }
    
    public static implicit operator string(Username username) => username.Value;
}