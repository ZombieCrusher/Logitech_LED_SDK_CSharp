#pragma warning disable IDE0130 // Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Logitech SDK key names used by per-key lighting operations.
    /// </summary>
    public enum KeyboardKeys : int
    {
        /// <summary>Escape key.</summary>
        ESC = 0x01,
        /// <summary>F1 key.</summary>
        F1 = 0x3B,
        /// <summary>F2 key.</summary>
        F2 = 0x3C,
        /// <summary>F3 key.</summary>
        F3 = 0x3D,
        /// <summary>F4 key.</summary>
        F4 = 0x3E,
        /// <summary>F5 key.</summary>
        F5 = 0x3F,
        /// <summary>F6 key.</summary>
        F6 = 0x40,
        /// <summary>F7 key.</summary>
        F7 = 0x41,
        /// <summary>F8 key.</summary>
        F8 = 0x42,
        /// <summary>F9 key.</summary>
        F9 = 0x43,
        /// <summary>F10 key.</summary>
        F10 = 0x44,
        /// <summary>F11 key.</summary>
        F11 = 0x57,
        /// <summary>F12 key.</summary>
        F12 = 0x58,
        /// <summary>Print Screen key.</summary>
        PRINT_SCREEN = 0x137,
        /// <summary>Scroll Lock key.</summary>
        SCROLL_LOCK = 0x46,
        /// <summary>Pause/Break key.</summary>
        PAUSE_BREAK = 0x145,
        /// <summary>Tilde key.</summary>
        TILDE = 0x29,
        /// <summary>Top-row 1 key.</summary>
        ONE = 0x02,
        /// <summary>Top-row 2 key.</summary>
        TWO = 0x03,
        /// <summary>Top-row 3 key.</summary>
        THREE = 0x04,
        /// <summary>Top-row 4 key.</summary>
        FOUR = 0x05,
        /// <summary>Top-row 5 key.</summary>
        FIVE = 0x06,
        /// <summary>Top-row 6 key.</summary>
        SIX = 0x07,
        /// <summary>Top-row 7 key.</summary>
        SEVEN = 0x08,
        /// <summary>Top-row 8 key.</summary>
        EIGHT = 0x09,
        /// <summary>Top-row 9 key.</summary>
        NINE = 0x0A,
        /// <summary>Top-row 0 key.</summary>
        ZERO = 0x0B,
        /// <summary>Minus key.</summary>
        MINUS = 0x0C,
        /// <summary>Equals key.</summary>
        EQUALS = 0x0D,
        /// <summary>Backspace key.</summary>
        BACKSPACE = 0x0E,
        /// <summary>Insert key.</summary>
        INSERT = 0x152,
        /// <summary>Home key.</summary>
        HOME = 0x147,
        /// <summary>Page Up key.</summary>
        PAGE_UP = 0x149,
        /// <summary>Num Lock key.</summary>
        NUM_LOCK = 0x45,
        /// <summary>Numeric keypad slash key.</summary>
        NUM_SLASH = 0x135,
        /// <summary>Numeric keypad asterisk key.</summary>
        NUM_ASTERISK = 0x37,
        /// <summary>Numeric keypad minus key.</summary>
        NUM_MINUS = 0x4A,
        /// <summary>Tab key.</summary>
        TAB = 0x0F,
        /// <summary>Q key.</summary>
        Q = 0x10,
        /// <summary>W key.</summary>
        W = 0x11,
        /// <summary>E key.</summary>
        E = 0x12,
        /// <summary>R key.</summary>
        R = 0x13,
        /// <summary>T key.</summary>
        T = 0x14,
        /// <summary>Y key.</summary>
        Y = 0x15,
        /// <summary>U key.</summary>
        U = 0x16,
        /// <summary>I key.</summary>
        I = 0x17,
        /// <summary>O key.</summary>
        O = 0x18,
        /// <summary>P key.</summary>
        P = 0x19,
        /// <summary>Open bracket key.</summary>
        OPEN_BRACKET = 0x1A,
        /// <summary>Close bracket key.</summary>
        CLOSE_BRACKET = 0x1B,
        /// <summary>Backslash key.</summary>
        BACKSLASH = 0x2B,
        /// <summary>Delete key.</summary>
        KEYBOARD_DELETE = 0x153,
        /// <summary>End key.</summary>
        END = 0x14F,
        /// <summary>Page Down key.</summary>
        PAGE_DOWN = 0x151,
        /// <summary>Numeric keypad 7 key.</summary>
        NUM_SEVEN = 0x47,
        /// <summary>Numeric keypad 8 key.</summary>
        NUM_EIGHT = 0x48,
        /// <summary>Numeric keypad 9 key.</summary>
        NUM_NINE = 0x49,
        /// <summary>Numeric keypad plus key.</summary>
        NUM_PLUS = 0x4E,
        /// <summary>Caps Lock key.</summary>
        CAPS_LOCK = 0x3A,
        /// <summary>A key.</summary>
        A = 0x1E,
        /// <summary>S key.</summary>
        S = 0x1F,
        /// <summary>D key.</summary>
        D = 0x20,
        /// <summary>F key.</summary>
        F = 0x21,
        /// <summary>G key.</summary>
        G = 0x22,
        /// <summary>H key.</summary>
        H = 0x23,
        /// <summary>J key.</summary>
        J = 0x24,
        /// <summary>K key.</summary>
        K = 0x25,
        /// <summary>L key.</summary>
        L = 0x26,
        /// <summary>Semicolon key.</summary>
        SEMICOLON = 0x27,
        /// <summary>Apostrophe key.</summary>
        APOSTROPHE = 0x28,
        /// <summary>Enter key.</summary>
        ENTER = 0x1C,
        /// <summary>Numeric keypad 4 key.</summary>
        NUM_FOUR = 0x4B,
        /// <summary>Numeric keypad 5 key.</summary>
        NUM_FIVE = 0x4C,
        /// <summary>Numeric keypad 6 key.</summary>
        NUM_SIX = 0x4D,
        /// <summary>Left Shift key.</summary>
        LEFT_SHIFT = 0x2A,
        /// <summary>Z key.</summary>
        Z = 0x2C,
        /// <summary>X key.</summary>
        X = 0x2D,
        /// <summary>C key.</summary>
        C = 0x2E,
        /// <summary>V key.</summary>
        V = 0x2F,
        /// <summary>B key.</summary>
        B = 0x30,
        /// <summary>N key.</summary>
        N = 0x31,
        /// <summary>M key.</summary>
        M = 0x32,
        /// <summary>Comma key.</summary>
        COMMA = 0x33,
        /// <summary>Period key.</summary>
        PERIOD = 0x34,
        /// <summary>Forward slash key.</summary>
        FORWARD_SLASH = 0x35,
        /// <summary>Right Shift key.</summary>
        RIGHT_SHIFT = 0x36,
        /// <summary>Up arrow key.</summary>
        ARROW_UP = 0x148,
        /// <summary>Numeric keypad 1 key.</summary>
        NUM_ONE = 0x4F,
        /// <summary>Numeric keypad 2 key.</summary>
        NUM_TWO = 0x50,
        /// <summary>Numeric keypad 3 key.</summary>
        NUM_THREE = 0x51,
        /// <summary>Numeric keypad Enter key.</summary>
        NUM_ENTER = 0x11C,
        /// <summary>Left Control key.</summary>
        LEFT_CONTROL = 0x1D,
        /// <summary>Left Windows key.</summary>
        LEFT_WINDOWS = 0x15B,
        /// <summary>Left Alt key.</summary>
        LEFT_ALT = 0x38,
        /// <summary>Space bar.</summary>
        SPACE = 0x39,
        /// <summary>Right Alt key.</summary>
        RIGHT_ALT = 0x138,
        /// <summary>Right Windows key.</summary>
        RIGHT_WINDOWS = 0x15C,
        /// <summary>Application select key.</summary>
        APPLICATION_SELECT = 0x15D,
        /// <summary>Right Control key.</summary>
        RIGHT_CONTROL = 0x11D,
        /// <summary>Left arrow key.</summary>
        ARROW_LEFT = 0x14B,
        /// <summary>Down arrow key.</summary>
        ARROW_DOWN = 0x150,
        /// <summary>Right arrow key.</summary>
        ARROW_RIGHT = 0x14D,
        /// <summary>Numeric keypad 0 key.</summary>
        NUM_ZERO = 0x52,
        /// <summary>Numeric keypad period key.</summary>
        NUM_PERIOD = 0x53,
        /// <summary>G1 programmable key.</summary>
        G_1 = 0xFFF1,
        /// <summary>G2 programmable key.</summary>
        G_2 = 0xFFF2,
        /// <summary>G3 programmable key.</summary>
        G_3 = 0xFFF3,
        /// <summary>G4 programmable key.</summary>
        G_4 = 0xFFF4,
        /// <summary>G5 programmable key.</summary>
        G_5 = 0xFFF5,
        /// <summary>G6 programmable key.</summary>
        G_6 = 0xFFF6,
        /// <summary>G7 programmable key.</summary>
        G_7 = 0xFFF7,
        /// <summary>G8 programmable key.</summary>
        G_8 = 0xFFF8,
        /// <summary>G9 programmable key.</summary>
        G_9 = 0xFFF9,
        /// <summary>Logitech G logo key or zone.</summary>
        G_LOGO = 0xFFFF1,
        /// <summary>Logitech G badge key or zone.</summary>
        G_BADGE = 0xFFFF2
    }
}
