using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearnApps.Server.Data;
using LearnApps.Shared;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LearnApps.Server.Services.FlashCardService
{
    public class FlashCardService : IFlashCardService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FlashCardService(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<FlashCardCreateDTO>> Get(FlashCardFilter filter)
        {

            return await context.FlashCards
                .Include(x => x.Decks)
                .Where(x => x.Decks.Any(y => y.Id == filter.DeckId))
                .ProjectTo<FlashCardCreateDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

        }

        public async Task<FlashCardDTO> Get(Guid id)
        {
            return await context.FlashCards
                .ProjectTo<FlashCardDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<FlashCardDTO> Post(FlashCardCreateDTO flashCardDTO)
        {
            FlashCard flashCard = mapper.Map<FlashCard>(flashCardDTO);
            if (flashCardDTO.Decks != default)
            {
                var decks = await context.Decks.Where(x => flashCardDTO.Decks.Contains(x.Id)).ToListAsync();
                flashCard.Decks = new List<Deck>();
                flashCard.Decks.AddRange(decks);
            }
            await context.FlashCards.AddAsync(flashCard);
            await context.SaveChangesAsync();
            return mapper.Map<FlashCardDTO>(flashCard);
        }

        public async Task<FlashCardDTO> Put(FlashCardCreateDTO flashCardDTO)
        {
            FlashCard flashCard = mapper.Map<FlashCardCreateDTO, FlashCard>(flashCardDTO);

            context.FlashCards.Update(flashCard);
            await context.SaveChangesAsync();
            return mapper.Map<FlashCardDTO>(flashCard);
        }
        public async Task<bool> Delete(Guid id)
        {
            FlashCard flashCard = await context.FlashCards.FirstOrDefaultAsync(x => x.Id.Equals(id));
            context.FlashCards.Remove(flashCard);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
