namespace RajoSpritButik;

internal class ChangePageRequest()
{
    public string Page { get; set; } = "";
    public object? Query { get; set; }
    public RequestAction Action { get; set; }
    public ChangePageRequest? Redirect { get; set; }
    
}

public enum RequestAction
{
    Get,
    Post,
    Delete,
    Patch
}