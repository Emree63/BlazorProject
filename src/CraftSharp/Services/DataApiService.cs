using CraftSharp.Components;
using CraftSharp.Factories;
using CraftSharp.Models;
using Microsoft.Extensions.Logging;

namespace CraftSharp.Services
{
    public class DataApiService : IDataService
    {
        private readonly HttpClient _http;
        private readonly ILogger<DataApiService> _logger;

        public DataApiService(
            HttpClient http, ILogger<DataApiService> logger)
        {
            _http = http;
            _logger = logger;
        }

        public async Task Add(ItemModel model)
        {
            // Get the item
            var item = ItemFactory.Create(model);

            // Save the data
            await _http.PostAsJsonAsync("https://localhost:7234/api/Crafting/", item);
            _logger.Log(LogLevel.Information, $"ADDITION OF ITEM : {model.Id} - {model.Name}");
        }

        public async Task<int> Count()
        {
            return await _http.GetFromJsonAsync<int>("https://localhost:7234/api/Crafting/count");
        }

        public async Task<List<Item>> List(int currentPage, int pageSize)
        {
            return await _http.GetFromJsonAsync<List<Item>>($"https://localhost:7234/api/Crafting/?currentPage={currentPage}&pageSize={pageSize}");
        }

        public async Task<Item> GetById(int id)
        {
            return await _http.GetFromJsonAsync<Item>($"https://localhost:7234/api/Crafting/{id}");
        }

        public async Task Update(int id, ItemModel model)
        {
            // Get the item
            var item = ItemFactory.Create(model);
            await _http.PutAsJsonAsync($"https://localhost:7234/api/Crafting/{id}", item);
            _logger.Log(LogLevel.Information, $"UPDATING ITEM : {model.Id} - {model.Name}");
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"https://localhost:7234/api/Crafting/{id}");
            _logger.Log(LogLevel.Information, $"DELETION ON ITEM : {id}");
        }

        public async Task<List<CraftingRecipe>> GetRecipes()
        {
            return await _http.GetFromJsonAsync<List<CraftingRecipe>>("https://localhost:7234/api/Crafting/recipe");
        }
    }
}
