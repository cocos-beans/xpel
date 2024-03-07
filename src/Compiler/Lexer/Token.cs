namespace XPEL.Compiler.Lexer
{
    public class Token(TokenType type, /*string lexeme,*/ object literal)
    {
        public TokenType Type { get; } = type;
        //public string Lexeme { get; } = lexeme;
        public object Literal { get; } = literal;
    }

    public enum TokenType
    {
        BRACKET_OPEN, BRACKET_CLOSE,  
        
        BRACE_OPEN, BRACE_CLOSE,  
        
        PARENTHESIS_OPEN, PARENTHESIS_CLOSE,  
        
        QUOTE_BACKTICK, QUOTE_DOUBLE, QUOTE_SINGLE,  
        
        AND, AT, BACKSLASH, BANG,  
        COLON, COMMA, DOLLAR,  
        PERCENT, PERIOD, PIPE,  
        POUND, QUESTION, SEMICOLON,  
        TILDE, UNDERSCORE,  
        
        PLUS, DASH, SLASH, ASTERISK,  
        
        GREATER, LESS, EQUAL,
        
        DO, FN, IF, IN, OF,
        BIN, EOF, FOR, INT, MUT, NEW, USE,
        BOOL, CASE, CHAR, ENUM, FROM, GATE, NULL, RULE, STRL, TRUE, TYPE, VOID,
        ARRAY, BREAK, CLASS, FALSE, RANGE, WHILE,
        CALLED, CONFIG, EXPORT, IGNORE, OBJECT, RETURN, STRUCT, SWITCH,
        CONTINUE,
        
        NUMBER, IDENTIFIER, SPACE
    }
}
