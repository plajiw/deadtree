using DeadTree.Domain.Constants;

namespace DeadTree.Domain.ValueObjects;

public record class Email
{
    private string Value { get; init; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException(ErrorCodes.EmailRequired);
        if (!RegexPatterns.Email().IsMatch(value))
            throw new DomainException(ErrorCodes.EmailInvalid);
        
        Value = value;
    }
    
    public static implicit operator string(Email email) => email.Value;
}