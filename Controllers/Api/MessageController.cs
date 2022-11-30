using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_razor_layout.Models.Repositories;
using la_mia_pizzeria_razor_layout.Models;

namespace la_mia_pizzeria_razor_layout.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        IDbPizzaRepository _pizzaRepository;

        public MessageController(IDbPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpPost]
        public IActionResult Create( Message message)
        {

            try
            {
                _pizzaRepository.AddMessage(message);

            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

            return Ok(message);
        }


    }
}
