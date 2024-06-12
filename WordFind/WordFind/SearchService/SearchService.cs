using WordFind.Interface;
using WordFind.Model;

namespace WordFind.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public SearchService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public bool isAuthTokenValid(string authToken)
        {
            return _tokenRepository.isTokenValid(authToken);
        }

        private static readonly HashSet<string> ReservedKeywords = new HashSet<string>
{
        "if", "else", "for", "while", "do", "switch", "case", "default", "break",
        "continue", "return", "try", "catch", "finally", "throw", "new", "this",
        "typeof", "instanceof", "delete", "in", "of", "import", "export", "class",
        "interface", "enum", "type", "namespace",
        "yield", "await", "async",
        "extends", "implements", "package", "super","class"
};
        public List<SearchResult> performSearch(SearchRequest request)
        {
            List<SearchResult> results = new List<SearchResult>();

            try
            {
                string[] files = Directory.GetFiles(request.folderPath, request.selectedExtension, SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    string fileExtension = Path.GetExtension(file).ToLower();
                    fileExtension = "*" + fileExtension;
                    string[] lines = File.ReadAllLines(file);
                    string currentMethodName = "";

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (isMethodStart(lines[i], fileExtension))
                        {
                            currentMethodName = extractMethodName(lines[i], fileExtension);
                        }

                        if ((!String.IsNullOrEmpty(file)) && (lines[i].Contains(request.searchCriteria)))
                        {
                            results.Add(new SearchResult
                            {
                                fileName = Path.GetFileName(file),
                                filePath = Path.GetDirectoryName(file),
                                folderName = Path.GetFileName(Path.GetDirectoryName(file)),
                                lineNumber = i + 1,
                                methodName = currentMethodName

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing search: {ex.Message}");
            }

            return results;
        }


        private bool isMethodStart(string strLine, string fileExtension)
        {
            strLine = strLine.Trim();

            if (fileExtension.Equals("*.ts", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals("*.js", StringComparison.OrdinalIgnoreCase))
            {
                return IsScriptMethodStart(strLine);
            }

            return ((strLine.StartsWith("def ") || strLine.StartsWith("function") || strLine.StartsWith("void") || strLine.StartsWith("int") || strLine.StartsWith("boolean") || strLine.StartsWith("string") ||
             strLine.StartsWith("public ") || strLine.StartsWith("private ") || strLine.StartsWith("protected ") || strLine.StartsWith("internal ") ||
             strLine.StartsWith("static ") || strLine.StartsWith("virtual ") || strLine.StartsWith("abstract ") || strLine.StartsWith("public synchronized ") ||
             strLine.StartsWith("private synchronized "))
            && (strLine.Contains("(") && !strLine.Contains("=")));
        }

        private bool IsScriptMethodStart(string strLine)
        {
            bool isMethodLine = strLine.Contains("(") && strLine.Contains(")") && (strLine.Contains("{"));
            bool isArrowFunction = strLine.Contains("=>");
            if (isArrowFunction)
            {
                return !strLine.Contains(":") && !strLine.Contains(".") && strLine.Contains("=>") && !StartsWithReservedKeyword(strLine);
            }
            return isMethodLine && !strLine.Contains("=>") && !strLine.Contains(".") && !strLine.Contains("else if") && !StartsWithReservedKeyword(strLine);
        }

        private bool StartsWithReservedKeyword(string strLine)
        {
            string firstWord = strLine.Split(new[] { ' ', '(', '{' }, StringSplitOptions.RemoveEmptyEntries)[0];
            return ReservedKeywords.Contains(firstWord);
        }

        private string extractMethodName(string strLine, string fileExtension)
        {
            strLine = strLine.Trim();

            if (fileExtension.Equals("*.ts", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals("*.js", StringComparison.OrdinalIgnoreCase))
            {
                return ExtractScriptMethodName(strLine);
            }

            string[] parts = strLine.Split('(');
            string[] methodNameParts = parts[0].Split(' ');
            return methodNameParts[^1];
        }

        private string ExtractScriptMethodName(string strLine)
        {
            if (strLine.Contains("=>"))
            {
                string[] parts = strLine.Split("=>");
                string[] parts1 = parts[0].Split("=");
                string[] partstrim = parts1[0].Trim().Split(' ');
                return partstrim[^1];
            }
            else
            {
                string[] parts = strLine.Split('(');
                string methodNamePart = parts[0].Trim();
                string[] methodNameParts = methodNamePart.Split(' ');
                return methodNameParts[^1];
            }
        }
    }
}
