using System;

namespace PhotinoNET
{
    public struct Keys
    {
        private Keys(string label, char valueWindows, string valueMacOS) => 
            (Label, ValueWindows, ValueMacOS) = (label, valueWindows, valueMacOS);

        private Keys(char value) : this(new string(new[] { value }), value, new string(new[] { value })) { }

        internal string Label;
        internal char ValueWindows;
        internal string ValueMacOS;

        public static readonly Keys A = new('A');
        public static readonly Keys B = new('B');
        public static readonly Keys C = new('C');
        public static readonly Keys D = new('D');
        public static readonly Keys E = new('E');
        public static readonly Keys F = new('F');
        public static readonly Keys G = new('G');
        public static readonly Keys H = new('H');
        public static readonly Keys I = new('I');
        public static readonly Keys J = new('J');
        public static readonly Keys K = new('K');
        public static readonly Keys L = new('L');
        public static readonly Keys M = new('M');
        public static readonly Keys N = new('N');
        public static readonly Keys O = new('O');
        public static readonly Keys P = new('P');
        public static readonly Keys Q = new('Q');
        public static readonly Keys R = new('R');
        public static readonly Keys S = new('S');
        public static readonly Keys T = new('T');
        public static readonly Keys U = new('U');
        public static readonly Keys V = new('V');
        public static readonly Keys W = new('W');
        public static readonly Keys X = new('X');
        public static readonly Keys Y = new('Y');
        public static readonly Keys Z = new('Z');
        public static readonly Keys D0 = new('0');
        public static readonly Keys D1 = new('1');
        public static readonly Keys D2 = new('2');
        public static readonly Keys D3 = new('3');
        public static readonly Keys D4 = new('4');
        public static readonly Keys D5 = new('5');
        public static readonly Keys D6 = new('6');
        public static readonly Keys D7 = new('7');
        public static readonly Keys D8 = new('8');
        public static readonly Keys D9 = new('9');
        public static readonly Keys F1 = new("F1", (char)0x70, "F1");
        public static readonly Keys F2 = new("F2", (char)0x71, "F2");
        public static readonly Keys F3 = new("F3", (char)0x72, "F3");
        public static readonly Keys F4 = new("F4", (char)0x73, "F4");
        public static readonly Keys F5 = new("F5", (char)0x74, "F5");
        public static readonly Keys F6 = new("F6", (char)0x75, "F6");
        public static readonly Keys F7 = new("F7", (char)0x76, "F7");
        public static readonly Keys F8 = new("F8", (char)0x77, "F8");
        public static readonly Keys F9 = new("F9", (char)0x78, "F9");
        public static readonly Keys F10 = new("F10", (char)0x79, "F10");
        public static readonly Keys F11 = new("F11", (char)0x7A, "F11");
        public static readonly Keys F12 = new("F12", (char)0x7B, "F12");
        public static readonly Keys Num0 = new("Numpad 0", (char)0x60, "0");
        public static readonly Keys Num1 = new("Numpad 1", (char)0x61, "1");
        public static readonly Keys Num2 = new("Numpad 2", (char)0x62, "2");
        public static readonly Keys Num3 = new("Numpad 3", (char)0x63, "3");
        public static readonly Keys Num4 = new("Numpad 4", (char)0x64, "4");
        public static readonly Keys Num5 = new("Numpad 5", (char)0x65, "5");
        public static readonly Keys Num6 = new("Numpad 6", (char)0x66, "6");
        public static readonly Keys Num7 = new("Numpad 7", (char)0x67, "7");
        public static readonly Keys Num8 = new("Numpad 8", (char)0x68, "8");
        public static readonly Keys Num9 = new("Numpad 9", (char)0x69, "9");
        public static readonly Keys Minus = new("-", (char)0xBD, "-");
        public static readonly Keys Plus = new("=", (char)0xBB, "=");
        public static readonly Keys Add = new("Numpad +", (char)0x6B, "+");
        public static readonly Keys Subtract = new("Numpad -", (char)0x6D, "-");
        public static readonly Keys Multiply = new("Numpad *", (char)0x6A, "*");
        public static readonly Keys Divide = new("Numpad /", (char)0x6F, "/");
        public static readonly Keys Decimal = new("Numpad .", (char)0x6E, ".");
        public static readonly Keys Quote = new("'", (char)0xDE, "'");
        public static readonly Keys Comma = new(",", (char)0xBC, ",");
        public static readonly Keys Period = new(".", (char)0xBE, ".");
        public static readonly Keys Semicolon = new(";", (char)0xBA, ";");
        public static readonly Keys Slash = new("/", (char)0xBF, "/");
        public static readonly Keys Backslash = new("\\", (char)0xDC, "\\");
        public static readonly Keys Tilde = new("~", (char)0xC0, "`");
        public static readonly Keys LeftBracket = new("[", (char)0xDB, "[");
        public static readonly Keys RightBracket = new("]", (char)0xDD, "]");
        public static readonly Keys Backspace = new("Backspace", (char)0x08, $"{(char)0x8}");
        public static readonly Keys Tab = new("Tab", '\t', "\t");
        public static readonly Keys Enter = new("Enter", '\r', "\r");
        public static readonly Keys Escape = new("Escape", (char)0x1B, null);
        public static readonly Keys PageUp = new("Page Up", (char)0x21, null);
        public static readonly Keys PageDown = new("Page Down", (char)0x22, null);
        public static readonly Keys End = new("End", (char)0x23, null);
        public static readonly Keys Home = new("Home", (char)0x24, null);    
        public static readonly Keys Left = new("Left", (char)0x25, null);
        public static readonly Keys Up = new("Up", (char)0x26, null);
        public static readonly Keys Right = new("Right", (char)0x27, null);
        public static readonly Keys Down = new("Down", (char)0x28, null);
        public static readonly Keys Insert = new("Insert", (char)0x2D, null);
        public static readonly Keys Delete = new("Delete", (char)0x2E, null);
    }

    [Flags]
    public enum ModifierKeys
    {
        None = 0,
        Control = 1,
        Shift = 2,
        Alt = 4,
    }
}