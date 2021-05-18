using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearnApps.Server.Data;
using LearnApps.Shared;
using LearnApps.Shared.ViewModels.DeckViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApps.Server.Services.DeckService
{
    [AllowAnonymous]
    public class DeckService : IDeckService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public DeckService(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DeckDTO>> GetAsync()
        {
            return await context.Decks
                .Include(x => x.FlashCards)
                //.AsNoTracking()
                .ProjectTo<DeckDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

            //return mapper.Map<List<DeckDTO>>(decks);
        }

        public async Task<DeckDTO> Get(Guid id)
        {
            /*
            var model = context.Find<Deck>(id);
            if(model != null) {
                context.Entry(model).Reference(m => m.FlashCards).Load();
                return mapper.Map<DeckDTO>(model);
            }
            */
            DeckDTO deck = await context.Decks
                .Include(x=>x.FlashCards)
                //.AsNoTracking()
                .ProjectTo<DeckDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            return deck;
            //return mapper.Map<DeckDTO>(deck);
        }

        public async Task<DeckDTO> Post(DeckDTO deckDTO)
        {
            Deck deck = mapper.Map<Deck>(deckDTO);
            await context.Decks.AddAsync(deck);
            await context.SaveChangesAsync();
            return deckDTO;
        }

        public async Task<DeckDTO> Put(DeckDTO deckDTO)
        {
            Deck deck = context.Decks
                .Include(x=>x.FlashCards)
                .FirstOrDefault(x => x.Id == deckDTO.Id);
            /*
            var model = context.Find<Deck>(deckDTO.Id);
            context.Entry(model).Reference(m => m.FlashCards).Load();
            */
            mapper.Map<DeckDTO, Deck>(deckDTO, deck);
            //context.Decks.Update(deck);
            await context.SaveChangesAsync();

            return deckDTO;
        }
        public async Task<bool> Delete(Guid id)
        {
            Deck deck = await context.Decks.FirstOrDefaultAsync(x => x.Id.Equals(id));
            context.Decks.Remove(deck);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<DeckDTO> AttachFlashCard(Guid deckId, Guid flashCardId)
        {
            var deck = context.Find<Deck>(deckId);
            var flashCard = context.Find<FlashCard>(flashCardId);

            deck.FlashCards.Add(flashCard);
            await context.SaveChangesAsync();

            return mapper.Map<DeckDTO>(deck);
        }
    }
}
