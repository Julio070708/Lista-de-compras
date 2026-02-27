using SQLite;

namespace Lista_de_compras.Models
{
    public class Produto
    {
        [PrimaryKey,AutoIncrement]
       public int Id { get; set; }
        public string Descrição { get; set; }
        public string Quantidade { get; set; }
        public string Preco { get; set; }    
    }
}
