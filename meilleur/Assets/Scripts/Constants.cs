namespace Constants {
    internal class PopHetimiul {
        public static readonly string[] EASY_QUESTIONS = new string[] {
            "How can we open and close tags?",
            "What is an image tag?",
            "Which tag is self closing?"
        };

        public static readonly string[,] EASY_OPTIONS = new string[,] {
            { "</p><p>", "</p></p>", "<p></p>" },
            { "p", "a", "img" },
            { "a", "img", "p" }
        };
        
        public static readonly string[] EASY_ANSWERS = new string[] {
            "<p></p>", "img", "img"
        };
        
        
        public static readonly string[] MEDIUM_QUESTIONS = new string[] {
            "Which tag is NOT a valid heading tag?",
            "What tag can we use to name the tab of the page?",
            "Where do we usually store the contents of the page?"
        };

        public static readonly string[,] MEDIUM_OPTIONS = new string[,] {
            { "h2", "h5", "h7" },
            { "title", "body", "p" },
            { "div", "title", "body" }
        };
        
        public static readonly string[] MEDIUM_ANSWERS = new string[] {
            "h7", "title", "body"
        };
        
        
        public static readonly string[] HARD_QUESTIONS = new string[] {
            "How to define an unordered list?",
            "How to define a list item?",
            "How can a divider tag NOT be defined?"
        };

        public static readonly string[,] HARD_OPTIONS = new string[,] {
            { "<li></li>", "<ul></ul>", "</ul>" },
            { "<li><li>", "<li></li>", "</li>" },
            { "<div />", "</div>", "<div></div>" }
        };
        
        public static readonly string[] HARD_ANSWERS = new string[] {
            "<ul></ul>", "<li></li>", "</div>"
        };
    }
    
    internal class PopCisius {
        public static readonly string[] EASY_QUESTIONS = new string[] {
            "How to style a paragraph tag?",
            "Which one of these is NOT a valid selector?",
            "How you can NOT select an element?"
        };

        public static readonly string[,] EASY_OPTIONS = new string[,] {
            { "p { }", "{ p }", "{ } p" },
            { "#name", ".name", "name" },
            { "id=\"abc\"", "id\"abc\"", "class=\"abc\"" }
        };
        
        public static readonly string[] EASY_ANSWERS = new string[] {
            "p { }", "name", "id\"abc\""
        };
        
        
        public static readonly string[] MEDIUM_QUESTIONS = new string[] {
            "How can you link an external CSS file?",
            "What is a valid rel value when referencing an external CSS file? (using <link> tag)",
            "How can a selected with class attribute element be used in CSS?"
        };

        public static readonly string[,] MEDIUM_OPTIONS = new string[,] {
            { "Using <link>", "Using <id>", "Using <class>" },
            { "stylesheet", "styleshet", "stilesheet" },
            { "#hello", "hello", ".hello" }
        };
        
        public static readonly string[] MEDIUM_ANSWERS = new string[] {
            "Using <link>", "stylesheet", ".hello"
        };
        
        
        public static readonly string[] HARD_QUESTIONS = new string[] {
            "How can you define styles within an HTML file?",
            "Where do you define external CSS file location?",
            "What is an extension name of CSS files?"
        };

        public static readonly string[,] HARD_OPTIONS = new string[,] {
            { "Using <link>", "Using <head>", "Using <style>" },
            { "Inside rel", "Inside head", "Inside href" },
            { ".cs", ".ccs", ".css" }
        };
        
        public static readonly string[] HARD_ANSWERS = new string[] {
            "Using <style>", "Inside href", ".css"
        };
    }
    
    internal class PopJuseno {
        public static readonly string[] EASY_QUESTIONS = new string[] {
            "Where can you define script file location?",
            "Using which keyword can you define a variable?",
            "How can you change text content of a selected element?"
        };

        public static readonly string[,] EASY_OPTIONS = new string[,] {
            { "In <script>", "In <head>", "In <style>" },
            { "lte", "let", "tel" },
            { "text", "content", "textContent" }
        };
        
        public static readonly string[] EASY_ANSWERS = new string[] {
            "In <script>", "let", "textContent"
        };
        
        
        public static readonly string[] MEDIUM_QUESTIONS = new string[] {
            "What button attribute can you use for capturing click events?",
            "How can you call a JavaScript function?",
            "Using which keyword can you define a function?"
        };

        public static readonly string[,] MEDIUM_OPTIONS = new string[,] {
            { "click", "onclick", "on" },
            { "paintMe()", "paintMe", "(paintMe)" },
            { "fun", "func", "function" }
        };
        
        public static readonly string[] MEDIUM_ANSWERS = new string[] {
            "onclick", "paintMe()", "function"
        };
        
        
        public static readonly string[] HARD_QUESTIONS = new string[] {
            "What is an extention of a JavaScript file?",
            "What keyword can be used to define a constant variable?",
            "Which property can you use to access querySelector function?"
        };

        public static readonly string[,] HARD_OPTIONS = new string[,] {
            { ".js", ".java", ".jss" },
            { "con", "const", "constant" },
            { "document", "doc", "docum" }
        };
        
        public static readonly string[] HARD_ANSWERS = new string[] {
            ".js", "const", "document"
        };
    }
}
