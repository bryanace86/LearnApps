using LearnApps.Shared;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApps.Server.Services.FlashCardService
{
    public interface IFlashCardService
    {
        Task<List<FlashCardCreateDTO>> Get(FlashCardFilter filter);
        Task<FlashCardDTO> Get(Guid id);
        Task<FlashCardDTO> Post(FlashCardCreateDTO deck);
        Task<FlashCardDTO> Put(FlashCardCreateDTO deck);
        Task<bool> Delete(Guid id);
    }
}
