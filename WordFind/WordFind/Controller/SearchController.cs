using Microsoft.AspNetCore.Mvc;
using WordFind.Interface;
using WordFind.Model;

namespace WordFind.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public ActionResult Search([FromBody] SearchRequest request)
        {
            if (!_searchService.isAuthTokenValid(request.authToken))
            {
                return Unauthorized("Invalid authentication token");
            }

            var results = _searchService.performSearch(request);
            return Ok(results);
        }
    }
}
