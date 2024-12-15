namespace prontuario.Domain.Entities.AccessCode;

public class PermissionEntity
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    public PermissionEntity() {}

    public PermissionEntity(long id, string title)
    {
        Id = id;
        Title = title;
    }
}