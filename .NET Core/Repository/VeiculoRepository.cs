using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackend.Data;
using TesteBackend.Models;

namespace TesteBackend.Repository
{
    public class VeiculoRepository
    {
        private readonly ApplicationContext context;

        public VeiculoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await context.Veiculos.ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> FindAsync(string term)
        {
            return await context.Veiculos.Where(x => (x.NomeVeiculo + " " + x.Descricao).Contains(term)).ToListAsync();
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await context.AddAsync(veiculo);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            context.Update(veiculo);
            await context.SaveChangesAsync();
        }

        public async Task<Veiculo> GetAsync(int id)
        {
            return await context.Veiculos.FindAsync(id);
        }

        public async Task DeleteAsync(Veiculo veiculo)
        {
            context.Remove(veiculo);
            await context.SaveChangesAsync();

        }
    }
}