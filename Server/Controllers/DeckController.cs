
using LearnApps.Server.Data;
using LearnApps.Server.Services.DeckService;
using LearnApps.Shared;
using LearnApps.Shared.ViewModels.DeckViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnApps.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {

        private readonly IDeckService deckService;

        public DeckController(IDeckService deckService)
        {
            this.deckService = deckService;
        }
        
        // GET: api/<DeckController>
        
        [HttpGet]
        public async Task<object> GetAsync()
        {
            List<DeckDTO> result = await deckService.GetAsync();

            var count = result.Count();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : result.Count();
                return new { Items = result.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return result;
            }

            //return new {Items = result, Count = result.Count() };
        }
        
        // GET api/<DeckController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeckDTO>> GetAsync(Guid id)
        {
            DeckDTO result = await deckService.Get(id);
            return Ok(result);
        }

        // POST api/<DeckController>
        [HttpPost]
        public async Task<ActionResult<Deck>> PostAsync([FromBody] DeckDTO deck)
        {
            DeckDTO result = await deckService.Post(deck);
            return Ok(result);
        }

        // PUT api/<DeckController>/5
        [HttpPut]
        public async Task<ActionResult<Deck>> PutAsync([FromBody] DeckDTO deck)
        {
            DeckDTO result = await deckService.Put(deck);
            return Ok(result);
        }

        // DELETE api/<DeckController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool result = await deckService.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong!");
            }
        }

        // PUT api/<DeckController>/5
        /*
        [HttpPut("{deckId}")]
        public async Task<ActionResult<Deck>> AttachFlashCard(Guid deckId, [FromBody] Guid flashCardId)
        {
            DeckDTO result = await deckService.AttachFlashCard(deckId, flashCardId);
            return Ok(result);
        }
        */
    }
}
