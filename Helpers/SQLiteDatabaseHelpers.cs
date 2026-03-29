using Lista_de_compras.Models;
using SQLite;

namespace Lista_de_compras.Helper
{
    public class SQLiteDatabaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelpers(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<int> Update(Produto p)
        {
            return _conn.UpdateAsync(p);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            return _conn.Table<Produto>()
                .Where(p => p.Descricao.Contains(q))
                .ToListAsync();
        }
    }
}
