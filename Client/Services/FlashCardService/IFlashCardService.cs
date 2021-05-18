using LearnApps.Shared;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LearnApps.Client.Services
{
    interface IFlashCardService
    {
        Task<List<FlashCard>> Get();
        Task<FlashCard> Get(Guid id);

        Task<HttpResponseMessage> Post(FlashCardDTO deck);
        Task<HttpResponseMessage> Put(FlashCard deck);
        Task<HttpResponseMessage> Delete(Guid id);
    }
}
