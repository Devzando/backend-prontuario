namespace prontuario.Domain.Entities.AccessCode;

public class PermissionEntityBuilder
{
    private long _id;
    private string? _title = string.Empty;

    public PermissionEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public PermissionEntityBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public PermissionEntity Build()
    {
        return new PermissionEntity(_id, _title!);
    }
}