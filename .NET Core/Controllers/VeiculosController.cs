using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBackend.Models;
using TesteBackend.Repository;

namespace TesteBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly VeiculoRepository veiculoRepository;

        public VeiculosController(VeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var veiculos = await veiculoRepository.GetAllAsync();

            return Ok(veiculos);
        }

        [HttpGet("{q}")]
        [Route("Find")]
        public async Task<IActionResult> Find([FromQuery] string q)
        {
            var veiculos = await veiculoRepository.FindAsync(q);

            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAction([FromRoute]int id)
        {
            var veiculo = await veiculoRepository.GetAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Veiculo veiculo)
        {
            await veiculoRepository.AddAsync(veiculo);

            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Veiculo dadosVeiculo, [FromRoute] int id)
        {
            var veiculo = await veiculoRepository.GetAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            veiculo.NomeVeiculo = dadosVeiculo.NomeVeiculo;
            veiculo.Descricao = dadosVeiculo.Descricao;
            veiculo.Marca = dadosVeiculo.Marca;
            veiculo.Vendido = dadosVeiculo.Vendido;

            await veiculoRepository.UpdateAsync(veiculo);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] IDictionary<string, string> dadosVeiculo, [FromRoute] int id)
        {
            var veiculo = await veiculoRepository.GetAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            foreach(var key in dadosVeiculo.Keys)
            {
                var propertyInfo = veiculo.GetType().GetProperties().Where(x => x.Name.ToLower().Contains(key.ToLower())).FirstOrDefault();
                propertyInfo.SetValue(veiculo, Convert.ChangeType(dadosVeiculo[key], propertyInfo.PropertyType), null);
            }

            await veiculoRepository.UpdateAsync(veiculo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var veiculo = await veiculoRepository.GetAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            await veiculoRepository.DeleteAsync(veiculo);

            return NoContent();
        }
    }
}