using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearnApps.Shared
{
    public class FlashCard: Entity
    {
        /*
        public FlashCard()
        {
            this.Decks = new HashSet<Deck>();
        }
        */
        [DisplayName("Image URL")]
        [Url(ErrorMessage = "Invalid URL!")]
        public string Image { get; set; }
        
        [DisplayName("Title")]
        [Required]
        [StringLength(100, ErrorMessage = "Title must be less than 100 characters!")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required]
        [StringLength(500, ErrorMessage = "Description must be less than 500 characters!")]
        public string Description { get; set; }

        [DisplayName("Level")]
        [Required]
        public int Level { get; set; }

        [JsonIgnore]
        public List<Deck> Decks { get; set; }
    }
}
