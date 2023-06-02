namespace TableModel;

public class Table
{
    public string Guid { get; set; } = default!;
    public string Name { get; set; } = default!;
    public List<Column> Columns { get; set; } = default!;
}