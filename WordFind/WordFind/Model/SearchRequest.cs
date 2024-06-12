namespace WordFind.Model
{
    public class SearchRequest
    {
        public string authToken { get; set; }
        public string searchCriteria { get; set; }
        public string selectedExtension { get; set; }
        public string folderPath { get; set; }
    }
}
