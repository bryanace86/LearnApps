using AutoMapper;
using LearnApps.Shared;
using LearnApps.Shared.ViewModels.DeckViewModels;
using System.Linq;

namespace LearnApps.Server.Automapper
{
    public class DeckProfile: Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, DeckDTO>()
                //.ForMember(x => x.FlashCards, opt => opt.MapFrom(x => x.FlashCards.Select(x => x.Id)))
                .ReverseMap();

        }
    }
}
