using Ambev.DeveloperEvaluation.Domain.Common;

public class ExternalBranch : BaseEntity
{
    public string Description { get; private set; }

    public ExternalBranch(Guid id, string description)
    {
        Id = id;
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public ExternalBranch()
    {
        
    }
}
