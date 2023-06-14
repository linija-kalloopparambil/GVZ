using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_API.Data.DTO;
using Pizza_API.Data.Model;
using Pizza_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Pizza_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaContext _pizzaContext;
        private readonly IMapper _mapper;
        public PizzaController(PizzaContext pizzaContext, IMapper mapper)
        {
            _pizzaContext = pizzaContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PizzaDTO>> Post([FromBody] PizzaDTO pizzadto)
        {
            var newPizza = _mapper.Map<Pizza>(pizzadto);
            _pizzaContext.Pizzas.Add(newPizza);
            await _pizzaContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = pizzadto.Id }, pizzadto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaDTO>>> GetAll()
        {
            var pizzalist = await _pizzaContext.Pizzas
                .Include(x => x.Toppings)
                .ToListAsync();

            return Ok(pizzalist);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDTO>> Get(int id)
        {
            var pizza = await _pizzaContext.Pizzas
                .Include(x => x.Toppings)
                .Where(y => y.Id == id).
                FirstOrDefaultAsync();
            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pizzaToDelete = await _pizzaContext.Pizzas
                //.Include(x => x.Toppings)
                .Where(y => y.Id == id)
                .FirstOrDefaultAsync();

            if (pizzaToDelete == null)
            {
                return NotFound();
            }
            _pizzaContext.Pizzas.Remove(pizzaToDelete);
            await _pizzaContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PizzaDTO>> Put(int id, PizzaDTO pizzadto)
        {
            if (id != pizzadto.Id)
            {
                return BadRequest();
            }
            var updatePizza = _mapper.Map<Pizza>(pizzadto);
            _pizzaContext.Pizzas.Update(updatePizza);
            await _pizzaContext.SaveChangesAsync();

            return Ok(updatePizza);
        }
    }
}
