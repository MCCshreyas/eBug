using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
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

        public Task<List<BugModel>> GetAllBugs()
        {
            return Task.FromResult(new List<BugModel>()
            {
                new() { Id = 1, Title = "First bug", Description = "First description"},
                new() { Id = 2, Title = "Second bug", Description = "Second description"},
            });
        }
    }
}