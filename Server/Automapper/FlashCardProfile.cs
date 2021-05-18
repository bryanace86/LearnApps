using AutoMapper;
using LearnApps.Shared;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApps.Server.Automapper
{
    public class FlashCardProfile: Profile
    {
        public FlashCardProfile()
        {
            CreateMap<FlashCard, FlashCardDTO>()
            //.ForMember(x => x.Decks, opt => opt.MapFrom(x => x.Decks.Select(x => x.Id)));
            .ReverseMap();

            CreateMap<FlashCardCreateDTO, FlashCard>()
                .ForMember(x => x.Decks, opt => opt.Ignore());

            CreateMap<FlashCard, FlashCardCreateDTO>()
                .ForMember(x => x.Decks, opt => opt.MapFrom(x => x.Decks.Select(x => x.Id)));

            //CreateMap<FlashCardDTO, FlashCard>();
            //.ForPath(x => x.Decks, opt => opt.MapFrom(x => x.Decks));
            //.ReverseMap();

        }
    }
}
