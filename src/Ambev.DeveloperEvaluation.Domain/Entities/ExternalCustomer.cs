using Ambev.DeveloperEvaluation.Domain.Common;

public class ExternalCustomer : BaseEntity
{
    public string Name { get; private set; }

    public ExternalCustomer(Guid id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public ExternalCustomer()
    {
        
    }
}
