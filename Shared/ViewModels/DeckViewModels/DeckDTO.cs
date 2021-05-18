using LearnApps.Shared.ViewModels.FlashCardViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApps.Shared.ViewModels.DeckViewModels
{
    public class DeckDTO: Entity
    {
        [DisplayName("Title")]
        [Required]
        [StringLength(100, ErrorMessage = "Title must be less than 100 characters!")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required]
        [StringLength(500, ErrorMessage = "Description must be less than 500 characters!")]
        public string Description { get; set; }

        public List<FlashCardDTO> FlashCards { get; set; }
    }
}
