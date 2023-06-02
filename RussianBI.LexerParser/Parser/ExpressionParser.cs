namespace RussianBI.LexerParser.Parser;

using Antlr4.Runtime;

public class ExpressionParser
{
    public RussianBIGrammarParser.RootContext ParseQuery(string query)
    {
        var parser = CreateParser(query);

        var tree = parser.root();

        return tree;
    }

    private RussianBIGrammarParser CreateParser(string input)
    {
        var inputStream = CharStreams.fromString(input);

        var lexer = new RussianBIGrammarLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);

        var parser = new RussianBIGrammarParser(tokenStream);

        return parser;
    }
}