using LearnApps.Shared;
using LearnApps.Shared.ViewModels.DeckViewModels;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LearnApps.Client.Services
{
    interface IDeckService
    {
        Task<List<DeckDTO>> Get();
        Task<DeckDTO> Get(Guid id);

        Task<HttpResponseMessage> Post(DeckDTO deck);
        Task<HttpResponseMessage> Put(DeckDTO deck);
        Task<HttpResponseMessage> Delete(Guid id);
        //Task<HttpResponseMessage> AttachFlashCard(Guid deck, Guid flashCard);
    }
}
