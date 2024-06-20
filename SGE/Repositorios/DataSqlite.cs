using System;
using Microsoft.EntityFrameworkCore;

namespace Repositorios;

    public class DataSqlite
    {

     public static void Inicializar()
    {
        using var context = new DataContext();
       if(context.Database.EnsureCreated()){
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
        Console.WriteLine("Se creo exitosamente La Base de Datos");
       }
       else 
        Console.WriteLine("ya existe");
    }
    }
