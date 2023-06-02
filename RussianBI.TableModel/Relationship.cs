namespace TableModel;

/// <summary>
/// Отношение между двумя таблицами.
/// </summary>
public class Relationship
{
    /// <summary>
    /// Идентификатор отношения.
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// Идентификатор исходной таблицы (откуда исходит связь)
    /// </summary>
    public string FromTableId { get; set; } = default!;

    /// <summary>
    /// Идентификатор колонки в исходной таблице (откуда исходит связь)
    /// </summary>
    public string FromColumnId { get; set; } = default!;
    
    /// <summary>
    /// Кардинальность колонки исходной таблицы.
    /// </summary>
    public Cardinality FromCardinality { get; set; } = Cardinality.Many;
    
    /// <summary>
    /// Идентификатор таблицы, в которую осуществляется связь.
    /// </summary>
    public string ToTableId { get; set; } = default!;
    
    /// <summary>
    /// Идентификатор колонки таблице, в которую осуществляется свзяь.
    /// </summary>
    public string ToColumnId { get; set; } = default!;
    
    /// <summary>
    /// Кардинальность колонки таблицы, в которую осуществляется связь.
    /// </summary>
    public Cardinality ToCardinality { get; set; } = Cardinality.One;
}

public enum Cardinality
{
    One = 1,
    Many = 2,
}