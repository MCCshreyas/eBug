using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eBug.Application.Contracts.Bugs;
using eBug.blazorUI.ViewModels;

namespace eBug.blazorUI.Services
{
    public class BugService
    {
        private readonly HttpClient _httpClient;

        public BugService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetAllBugsResponse>> GetAllBugs()
        {
            var bugsResult = await _httpClient.GetFromJsonAsync<List<GetAllBugsResponse>>("/api/bug");
            return bugsResult;
        }

        public async Task CreateBug(CreateBugCommand bug)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/bug", bug);
            result.EnsureSuccessStatusCode();
        }
    }
}