namespace RajoSpritButik;

internal abstract class Page
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool ShouldChangePage { get; set; }

    public Page()
    {
    }

    public abstract void Draw();
    public abstract void HandleInput();
    public abstract ChangePageRequest? ChangePage();
}
