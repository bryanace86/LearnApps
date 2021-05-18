
using LearnApps.Server.Data;
using LearnApps.Server.Services.DeckService;
using LearnApps.Server.Services.FlashCardService;
using LearnApps.Shared;
using LearnApps.Shared.ViewModels.FlashCardViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnApps.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashCardController : ControllerBase
    {

        private readonly IFlashCardService flashCardService;

        public FlashCardController(IFlashCardService flashCardService)
        {
            this.flashCardService = flashCardService;
        }

        // GET: api/<DeckController>
        [HttpGet]
        public async Task<object> GetAsync([FromQuery] FlashCardFilter filter)
        {
            List<FlashCardCreateDTO> result = await flashCardService.Get(filter);
            return new {Items = result, Count = result.Count };
        }
        
        // GET api/<DeckController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlashCardDTO>> GetAsync(Guid id)
        {
            FlashCardDTO result = await flashCardService.Get(id);
            return Ok(result);
        }

        // POST api/<DeckController>
        [HttpPost]
        public async Task<ActionResult<FlashCardDTO>> PostAsync([FromBody] FlashCardCreateDTO flashCard)
        {
            FlashCardDTO result = await flashCardService.Post(flashCard);
            return Ok(result);
        }

        // PUT api/<DeckController>/5
        [HttpPut]
        public async Task<ActionResult<FlashCardDTO>> PutAsync([FromBody] FlashCardCreateDTO deck)
        {
            FlashCardDTO result = await flashCardService.Put(deck);
            return Ok(result);
        }

        // DELETE api/<DeckController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool result = await flashCardService.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong!");
            }
        }
        
    }
}
