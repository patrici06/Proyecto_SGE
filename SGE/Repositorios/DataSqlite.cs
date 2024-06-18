
namespace Repositorios; 

public class DataSqlite
{
    public static void Incializar()//Encargado de Crear la Base de Datos Con el modelo definido  
    {                              //por las clases en DataContext.cs  
        using var context = new DataContext();
        if(context.Database.EnsureCreated()){ Console.WriteLine("Se creo base de datos");}

    }
}
