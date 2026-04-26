using SQLite;

namespace Lista_de_compras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { get; set; } = "";

        public double Quantidade { get; set; }

        public double Preco { get; set; }

        public double Total => Quantidade * Preco;

        // NOVO CAMPO (DESAFIO)
        public string Categoria { get; set; } = "";
    }
}