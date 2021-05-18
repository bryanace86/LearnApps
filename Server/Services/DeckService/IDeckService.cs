using LearnApps.Shared;
using LearnApps.Shared.ViewModels.DeckViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApps.Server.Services.DeckService
{
    public interface IDeckService
    {
        Task<List<DeckDTO>> GetAsync();
        Task<DeckDTO> Get(Guid id);
        Task<DeckDTO> Post(DeckDTO deck);
        Task<DeckDTO> Put(DeckDTO deck);
        Task<bool> Delete(Guid id);
        Task<DeckDTO> AttachFlashCard(Guid deck, Guid flashCard);
    }
}
