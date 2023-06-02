using TableModel;
using Antlr4.Runtime.Tree;
using System.Text;

namespace RussianBI.Sql;

public static class SqlBuilder
{
    private static SqlCodeState sqlCodeState { get; set; } = SqlCodeState.Generating;
    private static Stack<string> SqlFuncExpressions { get; set; } = new Stack<string>();
    private static string CurrentOperator { get; set; } = String.Empty;
    private static string CurrentColumn { get; set; } = String.Empty;
    private static string SelectExpression { get; set; } = String.Empty;
    private static string JoinExpression { get; set; } = String.Empty;
    private static string GroupByExpression { get; set; } = String.Empty;
    private static string AsExpression { get; set; } = String.Empty;

    public static string Build(RussianBIGrammarParser.RootContext tree, Model model)
    {
        // TODO Реализовать тело метода
        var stringExpressionSequense = new Stack<IParseTree>();
        var currentNodes = new Stack<IParseTree>();
        foreach (var _t in tree.children)
        {
            currentNodes.Push(_t);
        }

        // обход синтаксического дерева  
        while (currentNodes.Count > 0)
        {
            var currentNode = currentNodes.Pop();
            if (currentNode.ChildCount > 0)
            {
                for (int child = 0; child < currentNode.ChildCount; child++)
                {
                    currentNodes.Push(currentNode.GetChild(child));
                }
            }
            else
            {
                stringExpressionSequense.Push(currentNode);
                //Console.WriteLine(currentNode);
            }
        }

        string prevLiteral = null;
        string currentLiteral = null;
        foreach (var el in stringExpressionSequense)
        {
            currentLiteral = el.GetText();
            ContinueGenerateExpression(prevLiteral, currentLiteral);
            prevLiteral = currentLiteral;
        }

        GenerateJoinOperator(model);

        if (sqlCodeState == SqlCodeState.Generating)
        {
            return SelectExpression + JoinExpression + GroupByExpression;
        }

        return "error generating expression ...";
    }

    /// <summary>
    /// Метод, который проверяет возможность последущей генерации sql - запроса
    /// </summary>
    /// <param name="prevLiteral">предыдущий литерал</param>
    /// <param name="currentLiteral">текущий литерал</param>
    /// <returns>Возвращает ожидаемый следущий литерал</returns>
    private static string ContinueGenerateExpression(string prevLiteral, string currentLiteral)
    {
        switch (currentLiteral)
        {
            case "groupBy":
                if (sqlCodeState == SqlCodeState.Generating)
                {
                    if (prevLiteral != "calc")
                    {
                        sqlCodeState = SqlCodeState.NotSuccessForGenerated;
                        throw new Exception($"Not valid prev operator before groupBy");
                    }
                }
                CurrentOperator = "groupBy";
                return "(";
            case "(":
                if (sqlCodeState == SqlCodeState.Generating)
                {
                    if (prevLiteral == "groupBy" || prevLiteral == "SUM")
                    {
                        SqlFuncExpressions.Push(prevLiteral);
                    }
                    else
                    {
                        sqlCodeState = SqlCodeState.NotSuccessForGenerated;
                        throw new Exception($"Not valid prev operator before (");
                    }
                }
                CurrentOperator = "(";
                return "";
            case ")":            
                if (sqlCodeState == SqlCodeState.Generating)
                {
                    SqlFuncExpressions.Pop();
                }
                CurrentOperator = ")";
                return "";
            case ",":
                CurrentOperator = ",";
                return "";
            case "SUM":
                CurrentOperator = "SUM";
                return "(";
            case "calc":
                CurrentOperator = "calc";
                return "groupBy";
            default:
                if (sqlCodeState == SqlCodeState.Generating)
                {
                    if (CurrentOperator == "(")
                    {
                        var currentFuncExpression = SqlFuncExpressions.Peek();
                        if (currentLiteral.StartsWith('[') && currentLiteral.EndsWith(']'))
                        {
                            if (currentFuncExpression == "groupBy")
                            {
                                CurrentColumn += currentLiteral.Replace("[", "").Replace("]","");
                                GroupByExpression = GroupByOperator(CurrentColumn);
                                SelectExpression += string.IsNullOrEmpty(SelectExpression) ? SelectOperator(CurrentColumn) : ", " + CurrentColumn;
                                SelectExpression += AsExpression;
                                CurrentColumn = String.Empty;
                                return ",";
                            }
                            else if (currentFuncExpression == "SUM")
                            {
                                CurrentColumn += currentLiteral.Replace("[", "").Replace("]", "");
                                SelectExpression += string.IsNullOrEmpty(SelectExpression) ? SelectOperator($"sum({CurrentColumn})") : ", " + $"sum({CurrentColumn})";
                                SelectExpression += AsExpression;
                                CurrentColumn = String.Empty;
                                return ")";
                            }
                        }
                        else if (currentLiteral.StartsWith('\'') && currentLiteral.EndsWith('\''))
                        {
                            if (currentFuncExpression == "groupBy")
                            {
                                CurrentColumn = currentLiteral.Replace("'", "") + ".";
                                return ",";
                            }
                            else if (currentFuncExpression == "SUM")
                            {
                                CurrentColumn = currentLiteral.Replace("'", "") + ".";
                                return ")";
                            }
                        }
                    }
                    else
                    {
                        if (CurrentOperator == ",")
                        {
                            if (currentLiteral.StartsWith('"') && currentLiteral.EndsWith('"'))
                            {
                                AsExpression = AsOperator(currentLiteral.Replace('"', '\''));
                            }
                        }
                    }
                }
                return "";
        }
    }

    private static string GenerateJoinOperator(Model model)
    {
        var result  = new StringBuilder();
        var fact = "fact";
        var dim = "dim";
        foreach(var relation in model.Relationships)
        {
            var toTableId = relation.ToTableId;
            var fromTableId = relation.FromTableId;
            var fromColumnId = relation.FromColumnId;
            var toColumnId = relation.ToColumnId;
            var tableNameBeforeLeft = model.Tables.First(x => x.Guid == fromTableId)?.Name;
            var tableNameAfterLeft = model.Tables.First(x => x.Guid == toTableId)?.Name;
            var columnNameBefore = model.Tables.First(x => x.Guid == fromTableId)?.Columns?.First(x => x.Guid == fromColumnId).Name;
            var columnNameAfter = model.Tables.First(x => x.Guid == toTableId)?.Columns?.First(x => x.Guid == toColumnId).Name;
            if (string.IsNullOrEmpty(tableNameBeforeLeft) || string.IsNullOrEmpty(tableNameAfterLeft))
            {
                //throw new Exception($"Not valid data for tables");
            }
            result.Append(FromOperator()).Append(tableNameBeforeLeft).Append(" ").Append(fact).Append(LeftJoinOperator()).Append(tableNameAfterLeft).Append(" ").Append(dim).Append(OnOperator()).Append(fact).Append(".").Append(columnNameBefore).Append(" = ").Append(dim).Append(".").Append(columnNameAfter); 
        }
        JoinExpression = result.ToString();
        return JoinExpression;
    }

    private static string SelectOperator(string column)
    {
        return "select " + column;
    }

    private static string AsOperator(string as_column)
    {
        return " as " + as_column;
    }

    private static string FromOperator()
    {
        return " from ";
    }

    private static string LeftJoinOperator()
    {
        return " left join ";
    }

    private static string OnOperator()
    {
        return " on ";
    }

    private static string GroupByOperator(string column)
    { 
        return " group by " + column;
    }
}