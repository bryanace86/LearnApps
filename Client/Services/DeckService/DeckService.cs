using LearnApps.Shared;
using LearnApps.Shared.ViewModels.DeckViewModels;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LearnApps.Client.Services
{
    [AllowAnonymous]
    public class DeckService : IDeckService
    {
        private HttpClient http { get; }
        private IHttpClientFactory httpClientFactory { get; }

        public DeckService(HttpClient http, IHttpClientFactory httpClientFactory)
        {
            this.http = http;
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<HttpResponseMessage> Post(DeckDTO deck)
        {
            return await http.PostAsJsonAsync("api/Deck", deck);
        }

        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            return await http.DeleteAsync($"api/Deck/{id}");
        }

        [AllowAnonymous]
        public async Task<List<DeckDTO>> Get()
        {
            var httpAnon = httpClientFactory.CreateClient("LearnApps.AnonymousAPI");
            return await httpAnon.GetFromJsonAsync<List<DeckDTO>>("api/Deck");
        }

        public async Task<DeckDTO> Get(Guid id)
        {

            var httpAnon = httpClientFactory.CreateClient("LearnApps.AnonymousAPI");
            return await httpAnon.GetFromJsonAsync<DeckDTO>($"api/Deck/{id}");
        }

        public async Task<HttpResponseMessage> Put(DeckDTO deck)
        {
            return await http.PutAsJsonAsync("api/Deck", deck);
        }
        /*
        public async Task<DeckDTO> AttachFlashCard(Guid deckId, Guid flashCardId)
        {
            string requestUri = $"api/AttachFlashCard/{deckId}";
            DeckDTO result = await http.PutAsJsonAsync<DeckDTO>(requestUri, flashCardId);
            return result;
        }
        */
    }
}
