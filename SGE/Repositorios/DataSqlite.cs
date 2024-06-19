using System;
using Microsoft.EntityFrameworkCore;

namespace Repositorios
{
    public class DataSqlite
    {
        public static void Inicializar()
        {
            using var context = new DataContext();
            if (context.Database.EnsureCreated())
            {
                context.Database.EnsureCreated();
                var connection = context.Database.GetDbConnection();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
                }
                Console.WriteLine("Se creó la base de datos");
            }
            else
            {
                Console.WriteLine("La base de datos ya existe");
            }
        }
    }
}
