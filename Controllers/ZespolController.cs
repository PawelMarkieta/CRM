using Microsoft.AspNetCore.Mvc;
using CRMCallCenter.Interfaces;
using CRMCallCenter.DTO.Zespoly;
using Microsoft.AspNetCore.Http.HttpResults;


namespace CRMCallCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZespolController : ControllerBase
    {

        private readonly IZespolService _service;

        public ZespolController(IZespolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var zespoly = await _service.PobierzWszystkieAsync();
            return Ok(zespoly);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
        
            var zespol = await _service.PobierzPoIdAsync(id);
            if (zespol == null) return NotFound();
            return Ok(zespol);
        
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ZespolRequest request)
        {

            var nowy = await _service.DodajAsync(request);
            return CreatedAtAction(nameof(Get), new { id = nowy.Id }, nowy);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,  [FromBody] ZespolRequest request)
        {

            var wynik = await _service.EdytujAsync(id, request);
            return wynik ? NoContent() : NotFound();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var wynik = await _service.UsunAsync(id);
            return wynik ? NoContent() : NotFound();

        }


    }
}
