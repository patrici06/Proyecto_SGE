using Aplicacion;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
namespace Repositorios;

public class ControlRepositorios
{
    public static string RutaOrigen {get;set;}
    public static void AgregarRegistro(Object elem)
    {
        using (StreamWriter writer = new StreamWriter(RutaOrigen, true))
        {
            writer.WriteLine(elem);
            writer.Close();
        
        }
    }


    //Crea Archivo En la Ruta Necesario el manejo de excepciones
    public static void Crear ()
    {
        File.Create(RutaOrigen).Close();
    }
    // Crea Archivo Y carga el primer elemento.
    public static void Crear(Object elem)
{
    try
    {
         File.Create(RutaOrigen).Close(); // Debes cerrar el archivo después de crearlo para que pueda ser usado por otros procesos
         using(StreamWriter writer = new StreamWriter(RutaOrigen))
          {
               writer.WriteLine(elem);
               writer.Close();
          }
    }
    catch (Exception ex)
    {
        // Maneja cualquier excepción
        Console.WriteLine("Error: " + ex.Message);
    }
    }
    //Guarda Una lista con el elemento que coincida con el id del primer campo del to string
    //del objeto que reciba por parametro, permite solo colocar un id y eliminar exitosamente   
    public static void ElimiarRegistro(Object elem)
    {   
        LinkedList<string> temp = Safe();
        using(StreamWriter writer = new StreamWriter(RutaOrigen))
        {
        LinkedList<string> modificada = new LinkedList<string>();
        
        foreach(string act in temp)
        {
            string[]resumen = act.Split("\t");
            string[] Elem = elem.ToString().Split("\t");
            if (resumen[0] != Elem[0])
            {
              modificada.AddLast(act);
            }
        }
        foreach(string act in modificada)
        {
            writer.WriteLine(act);
        }
        writer.Close();
        }
     //Reparte la tarea de lectura y escritura en dos listas porque no es posible hacer las dos acciones
     //simultanesa
    }

    //Requiere Un Objeto ya modificado;
    public static void ModificarRegistro(Object elem)
    {
        LinkedList<string> temp = Safe();
        LinkedList<string> modificada = new LinkedList<string>();
        using(StreamWriter writer = new StreamWriter(RutaOrigen))
        {
            foreach(string act in temp)
            {
            string[] Act = act.Split("\t");
            string[] Elem = elem.ToString().Split("\t");
            if(Act[0] == Elem[0])
            {
                modificada.AddLast(elem.ToString());    
            } 
            else
            {
                modificada.AddLast(act);
            }
            }
            foreach(string aux in modificada)
            {
                writer.WriteLine(aux);
            }  
            writer.Close();
        }
        
    }
    //Retorna una linkedList Con Todos los elementos del archivo
    public static LinkedList<string> Safe()
    {
        using(StreamReader reader = new StreamReader(RutaOrigen)){
        LinkedList<string> temp = new LinkedList<string>();
        while(!reader.EndOfStream)
        {
            temp.AddLast(reader.ReadLine());
        }
        reader.Close();
        return temp;
        }
    }
}
