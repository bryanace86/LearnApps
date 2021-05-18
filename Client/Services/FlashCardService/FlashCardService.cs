using LearnApps.Shared;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LearnApps.Client.Services
{
    public class FlashCardService : IFlashCardService
    {
        private HttpClient http { get; }

        public FlashCardService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<HttpResponseMessage> Post(FlashCardDTO deck)
        {
            return await http.PostAsJsonAsync("api/FlashCard", deck);
        }

        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            return await http.DeleteAsync($"api/FlashCard/{id}");
        }

        public async Task<List<FlashCard>> Get()
        {
            return await http.GetFromJsonAsync<List<FlashCard>>("api/FlashCard");
        }

        public async Task<FlashCard> Get(Guid id)
        {
            return await http.GetFromJsonAsync<FlashCard>($"api/FlashCard/{id}");
        }

        public async Task<HttpResponseMessage> Put(FlashCard deck)
        {
            return await http.PutAsJsonAsync("api/FlashCard", deck);
        }
    }
}
