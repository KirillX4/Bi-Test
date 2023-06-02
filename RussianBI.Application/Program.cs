// See https://aka.ms/new-console-template for more information

using RussianBI.LexerParser.Parser;
using RussianBI.Sql;
using TableModel;

// Таблицы в системе
var tableModel = new TableModelProvider().GetTableModel();

// Формула - текстовый запрос от пользователя
var inputString = "calc groupBy('dimproduct'[name], \"measureName\", SUM('sales'[amount]))";
var parser = new ExpressionParser();

// Дерево лексера, которое строится по результатам парсинга запроса
var tree = parser.ParseQuery(inputString);

// TODO Реализовать тело метода
var resultSql = SqlBuilder.Build(tree, tableModel);

Console.WriteLine(resultSql);