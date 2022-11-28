using la_mia_pizzeria_razor_layout.Models;
using la_mia_pizzeria_razor_layout.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_razor_layout.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IDbPizzaRepository _pizzaRepository;

        public PizzaController(IDbPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Get()
        {
            List<Pizza> pizzas = _pizzaRepository.All();
            return Ok(pizzas);

        }



    }
}
