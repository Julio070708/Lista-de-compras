using Lista_de_compras.Models;
using SQLite;
namespace Lista_de_compras.Helper
{
    public class SQLiteDatabaseHelpers
    {readonly SQLiteAsyncConnection _conn;
        public SQLiteDatabaseHelpers(string path) 
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=? WHERE id=? ";
            return _conn.QueryAsync<Produto>(
                sql,p.Descrição,p.Quantidade,p.Preco,p.Id
                );
        }
        public Task <int>Delete(int id)
        { 
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }   
        public void GetAll() 
        {
            _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * Produto WHERE descricao LIKE ´%" + q + "%´";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
   
}
