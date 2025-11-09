using DeadTree.Domain.Constants;
using DeadTree.Domain.ValueObjects;

namespace DeadTree.Domain.Entities;

public class User
{
    private const int MaxLinks = 30;
    
    public string Id { get; private set; }
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public bool IsEmailConfirmed { get; private set; }
    public List<Link> Links { get; private set; } = [];
    public List<ExternalLogin> ExternalLogins { get; private set; } = [];
    public List<ServiceConnection> ServiceConnections { get; private set; } = [];
    public ProfileSettings Settings { get; private set; }

    public User (Username username, Email email, ProfileSettings settings)
    {
        Username = username;
        Email = email;
        Settings = settings;
        IsEmailConfirmed = false;
    }

    public void AddLink(Link link)
    {
        if (link == null) 
            throw new DomainException(ErrorCodes.LinkInvalid);
        if(Links.Count >= MaxLinks) 
            throw new DomainException(ErrorCodes.LinkLimitExceeded, MaxLinks);
        // link.Validate();
        Links.Add(link);
    }
    
    public void AddServiceConnection(ServiceConnection connection)
    {
        if (connection == null) 
            throw new DomainException(ErrorCodes.ServiceConnectionInvalid);
    }
}