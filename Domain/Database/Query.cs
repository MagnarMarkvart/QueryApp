namespace Domain.Database;

public class Query
{
    public Guid QueryId { get; set; }
    public string Description { get; set; } = default!;
    public EImportance? Importance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime? DealtWith { get; set; }
}