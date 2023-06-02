namespace TableModel;

public class TableModelProvider
{
    private readonly Model _model = new()
    {
        Tables = new List<Table>
        {
            new Table
            {
                Guid = "F905BB03-7A52-41ED-B3BD-53C8D29503A6",
                Name = "dimproduct",
                Columns = new List<Column>
                {
                    new()
                    {
                        Guid = "0EECDCC1-245C-4A8C-AEDC-BFFA2CA467D3",
                        Name = "key",
                        DataType = ColumnDataType.Number
                    },
                    new()
                    {
                        Guid = "E3157227-4878-4F76-8896-B6F0714852A3",
                        Name = "name",
                        DataType = ColumnDataType.String
                    }
                }
            },
            new Table
            {
                Guid = "74D1548E-CDFE-4DF3-A18C-9F07C32C2164",
                Name = "sales",
                Columns = new List<Column>
                {
                    new()
                    {
                        Guid = "8924D105-FBCE-4C39-AAF1-BBC050653CF6",
                        Name = "productkey",
                        DataType = ColumnDataType.Number
                    },
                    new()
                    {
                        Guid = "F0D0F625-9578-48AE-B4A3-7F136BA8AF99",
                        Name = "amount",
                        DataType = ColumnDataType.Number
                    }
                }
            }
        },
        Relationships = new List<Relationship>
        {
            new()
            {
                Id = "ED7E750F-C89A-42DC-9DC7-A81262BE97E2",
                FromTableId = "74D1548E-CDFE-4DF3-A18C-9F07C32C2164",
                FromColumnId = "8924D105-FBCE-4C39-AAF1-BBC050653CF6",
                FromCardinality = Cardinality.Many,
                ToTableId = "F905BB03-7A52-41ED-B3BD-53C8D29503A6",
                ToColumnId = "0EECDCC1-245C-4A8C-AEDC-BFFA2CA467D3",
                ToCardinality = Cardinality.One,
            }
        }
    };

    public Model GetTableModel() => _model;
}