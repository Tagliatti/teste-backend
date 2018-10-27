using System;

namespace TesteBackend.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string NomeVeiculo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public bool Vendido { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}