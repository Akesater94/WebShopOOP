namespace RajoSpritButik.UIComponents;

internal class Table<T>
{
    public List<T> Objects { get; set; }
    public string Title { get; set; }
    public string HeaderRow { get; set; }
    public string BottomRow{ get; set; } = string.Empty;
    public Func<T, int, string> RowFormatter { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }

    public Table(List<T> objects, string title, string headerRow, Func<T, int, string> rowFormatter, int left, int top)
    {
        Objects = objects;
        Title = title;
        HeaderRow = headerRow;
        RowFormatter = rowFormatter;
        Left = left;
        Top = top;
    }
    public Table(List<T> objects, string title, string headerRow, string bottomRow, Func<T, int, string> rowFormatter, int left, int top)
    {
        Objects = objects;
        Title = title;
        HeaderRow = headerRow;
        BottomRow = bottomRow;
        RowFormatter = rowFormatter;
        Left = left;
        Top = top;
    }

    public void Draw()
    {
        List<string> rows = new();
        rows.Add(HeaderRow);
        rows.Add("");

        for (int i = 0; i < Objects.Count; i++)
        {
            T obj = Objects[i];
            rows.Add(RowFormatter(obj, i));
        }

        if (BottomRow != string.Empty)
        {
            rows.Add(BottomRow);
        }
        Window window = new(Title, Left, Top, rows);
        window.Draw();
    }
}
