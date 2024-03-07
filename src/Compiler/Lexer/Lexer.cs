using System.Collections.Generic;
using static XPEL.Compiler.Lexer.Token;

namespace XPEL.Compiler.Lexer
{
    public class Lexer(string input)
    {
        private int _pos = 0;

        private readonly HashSet<string> _keyword = new()
        {
            "do", "fn", "if", "in", "of",
            "bin", "for", "int", "mut", "new", "use",
            "bool", "case", "char", "enum", "from", "gate",
            "null", "rule", "strl", "true", "type", "void",
            "array", "break", "class", "false", "range", "while",
            "called", "config", "export", "ignore", "object",
            "return", "struct", "switch", "continue"
        };

        public Token GetNextToken()
        {
            if (_pos >= input.Length) return new Token(TokenType.EOF, "");

            char curChar = input[_pos];

            if (char.IsDigit(curChar)) return ReadNumber();
            if (char.IsLetter(curChar)) return ReadWord();

            switch (curChar)
            {
                case ' ':
                    _pos++;
                    return new Token(TokenType.SPACE, @"\s");
                case '[':
                    _pos++;
                    return new Token(TokenType.BRACKET_OPEN, "[");
                case ']':
                    _pos++;
                    return new Token(TokenType.BRACKET_CLOSE, "]");
                case '{':
                    _pos++;
                    return new Token(TokenType.BRACE_OPEN, "{");
                case '}':
                    _pos++;
                    return new Token(TokenType.BRACE_CLOSE, "}");
                case '(':
                    _pos++;
                    return new Token(TokenType.PARENTHESIS_OPEN, "(");
                case ')':
                    _pos++;
                    return new Token(TokenType.PARENTHESIS_CLOSE, ")");
                case '`':
                    _pos++;
                    return new Token(TokenType.QUOTE_BACKTICK, "`");
                case '"':
                    _pos++;
                    return new Token(TokenType.QUOTE_DOUBLE, "\"");
                case '\'':
                    _pos++;
                    return new Token(TokenType.QUOTE_SINGLE, "'");
                case '&':
                    _pos++;
                    return new Token(TokenType.AND, "&");
                case '@':
                    _pos++;
                    return new Token(TokenType.AT, "]");
                case '\\':
                    _pos++;
                    return new Token(TokenType.BACKSLASH, @"\");
                case '!':
                    _pos++;
                    return new Token(TokenType.BANG, "!");
                case ':':
                    _pos++;
                    return new Token(TokenType.COLON, ":");
                case ',':
                    _pos++;
                    return new Token(TokenType.COMMA, ",");
                case '$':
                    _pos++;
                    return new Token(TokenType.DOLLAR, "$");
                case '%':
                    _pos++;
                    return new Token(TokenType.PERCENT, "%");
                case '.':
                    _pos++;
                    return new Token(TokenType.PERIOD, ".");
                case '|':
                    _pos++;
                    return new Token(TokenType.PIPE, "|");
                case '#':
                    _pos++;
                    return new Token(TokenType.POUND, "#");
                case '?':
                    _pos++;
                    return new Token(TokenType.QUESTION, "?");
                case ';':
                    _pos++;
                    return new Token(TokenType.SEMICOLON, ";");
                case '~':
                    _pos++;
                    return new Token(TokenType.TILDE, "~");
                case '_':
                    _pos++;
                    return new Token(TokenType.UNDERSCORE, "_");
                case '+':
                    _pos++;
                    return new Token(TokenType.PLUS, "+");
                case '-':
                    _pos++;
                    return new Token(TokenType.DASH, "-");
                case '*':
                    _pos++;
                    return new Token(TokenType.ASTERISK, "*");
                case '/':
                    _pos++;
                    return new Token(TokenType.SLASH, "/");
                case '>':
                    _pos++;
                    return new Token(TokenType.GREATER, ">");
                case '<':
                    _pos++;
                    return new Token(TokenType.LESS, "<");
                case '=':
                    _pos++;
                    return new Token(TokenType.EQUAL, "=");
                default:
                    throw new ArgumentException($"Invalid char \"{curChar}\"");
            }
        }

        private Token ReadNumber()
        {
            string num = "";

            while (_pos < input.Length && char.IsDigit(input[_pos]))
            {
                num += input[_pos];
                _pos++;
            }

            return new Token(TokenType.NUMBER, num);
        }

        private Token ReadWord()
        {
            string identifier = "";

            while (_pos < input.Length && (char.IsLetterOrDigit(input[_pos]) || input[_pos] == '_'))
            {
                identifier += input[_pos];
                _pos++;
            }

            if (_keyword.Contains(identifier))
            {
                switch (identifier)
                {
                    case "do":
                        return new Token(TokenType.DO, "do");
                    case "fn":
                        return new Token(TokenType.FN, "fn");
                    case "if":
                        return new Token(TokenType.IF, "if");
                    case "in":
                        return new Token(TokenType.IN, "in");
                    case "of":
                        return new Token(TokenType.OF, "of");
                    case "bin":
                        return new Token(TokenType.BIN, "bin");
                    case "for":
                        return new Token(TokenType.FOR, "for");
                    case "int":
                        return new Token(TokenType.INT, "int");
                    case "mut":
                        return new Token(TokenType.MUT, "mut");
                    case "new":
                        return new Token(TokenType.NEW, "new");
                    case "use":
                        return new Token(TokenType.USE, "use");
                    case "bool":
                        return new Token(TokenType.BOOL, "bool");
                    case "case":
                        return new Token(TokenType.CASE, "case");
                    case "char":
                        return new Token(TokenType.CHAR, "char");
                    case "enum":
                        return new Token(TokenType.ENUM, "enum");
                    case "from":
                        return new Token(TokenType.FROM, "from");
                    case "gate":
                        return new Token(TokenType.GATE, "gate");
                    case "null":
                        return new Token(TokenType.NULL, "null");
                    case "rule":
                        return new Token(TokenType.RULE, "rule");
                    case "strl":
                        return new Token(TokenType.STRL, "strl");
                    case "true":
                        return new Token(TokenType.TRUE, "true");
                    case "type":
                        return new Token(TokenType.TYPE, "type");
                    case "void":
                        return new Token(TokenType.VOID, "void");
                    case "array":
                        return new Token(TokenType.ARRAY, "array");
                    case "break":
                        return new Token(TokenType.BREAK, "break");
                    case "class":
                        return new Token(TokenType.CLASS, "class");
                    case "false":
                        return new Token(TokenType.FALSE, "false");
                    case "range":
                        return new Token(TokenType.RANGE, "range");
                    case "while":
                        return new Token(TokenType.WHILE, "while");
                    case "called":
                        return new Token(TokenType.CALLED, "called");
                    case "config":
                        return new Token(TokenType.CONFIG, "config");
                    case "export":
                        return new Token(TokenType.EXPORT, "export");
                    case "ignore":
                        return new Token(TokenType.IGNORE, "ignore");
                    case "object":
                        return new Token(TokenType.OBJECT, "object");
                    case "return":
                        return new Token(TokenType.RETURN, "return");
                    case "struct":
                        return new Token(TokenType.STRUCT, "struct");
                    case "switch":
                        return new Token(TokenType.SWITCH, "switch");
                    case "continue":
                        return new Token(TokenType.CONTINUE, "continue");
                    default:
                        throw new ArgumentException($"Unknown keyword \"{identifier}\"");
                }
            }

            return new Token(TokenType.IDENTIFIER, identifier);
        }
    }
}
