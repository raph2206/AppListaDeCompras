using AppMercadin.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMercadin.Helper
{

    public class SQLiteDatabaseHelper
    {

        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path)
        {
   
            _connection = new SQLiteAsyncConnection(path);

            _connection.CreateTableAsync<Produtos>().Wait();
        }

        public Task<int> Insert(Produtos p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Produtos>> Update(Produtos p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE id= ? ";
            return _connection.QueryAsync<Produtos>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        public Task<List<Produtos>> GetAll()
        {
            return _connection.Table<Produtos>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _connection.Table<Produtos>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produtos>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%' ";

            return _connection.QueryAsync<Produtos>(sql);
        }
    }
}