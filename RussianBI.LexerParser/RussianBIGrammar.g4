grammar RussianBIGrammar;

root: 'calc' groupByFunction;

groupByFunction : 'groupBy' LR_BRACKET groupByColumns ( ',' groupByCalculations )? RR_BRACKET;

column : TABLE_SELECTOR COLUMN_SELECTOR;

groupByColumns: column ( ',' column )* ;

groupByCalculations: groupByCalculation ( ',' groupByCalculation )* ;
groupByCalculation : measureName ',' sumFunc;
sumFunc:        'SUM' '(' column ')' ;

measureName:                  NON_EMPTY_STRING;

TABLE_SELECTOR:       '\'' (~['] | '\'\'')+ '\'' ;
COLUMN_SELECTOR:             '[' (~[\]] | ']]')+ ']' ;
LR_BRACKET:                 '(' ;
RR_BRACKET:                 ')' ;
WS:   [ \t\r\n]+ -> skip ;
NON_EMPTY_STRING:           '"' STRING_LETTER+ '"';
fragment STRING_LETTER:     (~["] | '""') ;
