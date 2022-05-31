using SQLite;
using System;

namespace AppMercadin.Model
{
    public class Tarefa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Preco { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime Data_Conclusao { get; set; }
    }
}
