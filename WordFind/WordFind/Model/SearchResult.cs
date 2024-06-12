namespace WordFind.Model
{
    public class SearchResult
    {
        public string? fileName { get; set; }
        public string? filePath { get; set; }
        public string? folderName { get; set; }
        public int lineNumber { get; set; }
        public string? methodName { get; set; }
    }
}
