using System.Collections.Generic;
using WordFind.Model;

namespace WordFind.Interface
{
    public interface ISearchService
    {
        bool isAuthTokenValid(string authToken);
        List<SearchResult> performSearch(SearchRequest request);
    }
}
