using Ambev.DeveloperEvaluation.Domain.Common;

public class ExternalProduct : BaseEntity
{
    public string Name { get; set; }

    public ExternalProduct(Guid id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public ExternalProduct()
    {

    }
}
