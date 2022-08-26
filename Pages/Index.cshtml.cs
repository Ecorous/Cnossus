using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharpRinth;
using SharpRinth.Enums;
using SharpRinth.Filtering;
using SharpRinth.Json;

namespace Cnossus.Pages;

public class IndexModel : PageModel
{
    public static ModHit mod;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


    public void OnGet()
    {
        

        ModrinthClient client = new();
        var hits = client.SearchMods().WithIndexing(SearchIndex.RecentlyAdded).WithLimit(20).Execute().Result.Results;
        Random rnd = new();
        int index = rnd.Next(hits.Length);
        var modHit = hits[index];
        mod = modHit;
    }
}
