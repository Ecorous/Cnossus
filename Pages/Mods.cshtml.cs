using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using SharpRinth;
using SharpRinth.Builders;
using SharpRinth.Enums;
using SharpRinth.Json;

namespace Cnossus.Pages;

public class ModsModel : PageModel
{
    private readonly ILogger<ModsModel> _logger;

    public static ExecuteResult<ModSearch> hits;

    public ModsModel(ILogger<ModsModel> logger)
    {
        _logger = logger;
    }

    public static string Truncate(string variable, int Length)
    {
        if (string.IsNullOrEmpty(variable)) return variable;
        return variable.Length <= Length ? variable : variable.Substring(0, Length);
    }

 /*   public static async Task<JsonElement[]> Search(List<List<String>>? facets = null, String? query = null, int limit = 0x06795345, int offset = 0x06795345, SortingIndex index = SortingIndex.NONE)
    {
        HttpClient client = new HttpClient();
        var url = "https://api.modrinth.com/v2/search";
        bool isParam = false;
        #region Parameter Handling

        

        
        #region Facets Handling
        if (facets != null)
        {
            isParam = true;
            var facetString = "[[";
            int i = 0;
            int ii = 0;
            foreach (var facet in facets)
            {

                foreach (var f in facet)
                {

                    if ((facet.Count - 1) == facet.LastIndexOf(f))
                    {
                        facetString += $"\"{f}\"]";
                    }
                    else
                    {
                        facetString += $"\"{f}\", ";
                    }

                    ii++;
                }

                if ((facets.Count - 1) != facets.LastIndexOf(facet))
                {
                    Console.WriteLine(facets.LastIndexOf(facet) + "/" + facets.Count);
                    facetString += ", ";
                }
                else
                {
                    facetString += "]";
                }

                i++;
            }
            if (isParam)
            {
                url += $"&facets={facetString}";
            }
            else
            {
                url += $"?facets={facetString}";
            }
            //Console.WriteLine(facetString);
            //await p.WriteAsync(facetString);
        }
        #endregion
        #region Query Handling

        if (query != null)
        {

        }
        #endregion

        #region Limit Handling

        if (limit != 0x06795345)
        {
            if (isParam)
            {
                url += $"&query={query}";
            }
            else
            {
                url += $"?query={query}";
            }
        }

        #endregion

        #region Offset Handling

        if (offset != 0x06795345)
        {
            if (isParam)
            {
                url += $"&offset={offset}";
            }
            else
            {
                url += $"?offset={offset}";
            }
        }

        #endregion

        #region Index/Sort Handling

        if (index != SortingIndex.NONE)
        {
            string indexString; 
            switch (index)
            {
                case SortingIndex.NEWEST:
                    indexString = "newest";
                    break;
                case SortingIndex.FOLLOWS:
                    indexString = "follows";
                    break;
                case SortingIndex.UPDATED:
                    indexString = "updated";
                    break;
                case SortingIndex.DOWNLOADS:
                    indexString = "downloads";
                    break;
                case SortingIndex.RELEVANCE:
                    indexString = "relevance";
                    break;
                default:
                    throw new Exception("Something went horribly wrong! Value index has impossible value!");
            }

            if (isParam)
            {
                url += $"&index={indexString}";
            }
            else
            {
                url += $"?index={indexString}";
                
            }
        }

        #endregion
        #endregion

        var out_ = await client.GetAsync(url);
        var Out = await out_.Content.ReadAsStringAsync();
        var out_json = JObject.Parse(Out);
        var hits = out_json.SelectToken("hits");
        
        return root;
    }*/

    public void OnGet()
    {

        ModrinthClient client = new();
        var response = client.SearchMods().WithOffset(0).WithIndexing(SearchIndex.Relevance).Execute();
        hits = response;
        //var res = Search(index: SortingIndex.NEWEST);
        //var resString = res.Result
    }
}

