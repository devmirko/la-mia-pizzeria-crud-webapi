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

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Pizza pizza = _pizzaRepository.GetById(id);


            if (pizza == null)
            {
                return NotFound("l'elemento non è stato trovato");
            }

            return Ok(pizza);

        }

        public IActionResult Search(string? Name, double? Price)
       {
            
            List<Pizza> pizza = _pizzaRepository.SearchByTitle( Name, (double)Price );
           

            return Ok(pizza);

        }



    }
}
