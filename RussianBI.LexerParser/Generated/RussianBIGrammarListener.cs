//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from RussianBIGrammar.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="RussianBIGrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IRussianBIGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.root"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRoot([NotNull] RussianBIGrammarParser.RootContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.root"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRoot([NotNull] RussianBIGrammarParser.RootContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.groupByFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroupByFunction([NotNull] RussianBIGrammarParser.GroupByFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.groupByFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroupByFunction([NotNull] RussianBIGrammarParser.GroupByFunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.column"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColumn([NotNull] RussianBIGrammarParser.ColumnContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.column"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColumn([NotNull] RussianBIGrammarParser.ColumnContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.groupByColumns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroupByColumns([NotNull] RussianBIGrammarParser.GroupByColumnsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.groupByColumns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroupByColumns([NotNull] RussianBIGrammarParser.GroupByColumnsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.groupByCalculations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroupByCalculations([NotNull] RussianBIGrammarParser.GroupByCalculationsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.groupByCalculations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroupByCalculations([NotNull] RussianBIGrammarParser.GroupByCalculationsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.groupByCalculation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroupByCalculation([NotNull] RussianBIGrammarParser.GroupByCalculationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.groupByCalculation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroupByCalculation([NotNull] RussianBIGrammarParser.GroupByCalculationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.sumFunc"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSumFunc([NotNull] RussianBIGrammarParser.SumFuncContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.sumFunc"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSumFunc([NotNull] RussianBIGrammarParser.SumFuncContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RussianBIGrammarParser.measureName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMeasureName([NotNull] RussianBIGrammarParser.MeasureNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RussianBIGrammarParser.measureName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMeasureName([NotNull] RussianBIGrammarParser.MeasureNameContext context);
}
