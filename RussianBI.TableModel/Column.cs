namespace TableModel;

public class Column
{
    public string Guid { get; set; } = default!;
    public string Name { get; set; } = default!;
    public ColumnDataType DataType { get; set; }
}