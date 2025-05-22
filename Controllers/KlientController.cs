using CRMCallCenter.DTO.Klienci;
using CRMCallCenter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRMCallCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlientController : ControllerBase
    {

        private readonly IKlientService _service;

        public KlientController(IKlientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var klienci = await _service.PobierzWszystkichAsync();
            return Ok(klienci);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var klient = await _service.PobierzPoIdAsync(id);
            if (klient == null) return NotFound();
            return Ok(klient);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KlientRequest request)
        {
            var nowy = await _service.DodajAsync(request);
            return CreatedAtAction(nameof(Get), new {id = nowy.Id}, nowy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] KlientRequest request)
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
