 namespace Repositorios;

using System.Collections.Generic;
using Aplicacion;
 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class ExpedienteRepositorio(TramitesRepositorio TR) : IExpedienteRepositorio
{
    public void AltaExpediente(Expediente expediente)
    {
       using  var db = new DataContext();
       db.Expedientes.Add( expediente );
       db.SaveChanges();
    }

    public void BajaExpediente(int idExpediente)
    {
        using var db = new DataContext(); 
        Expediente? expediente = db.Expedientes.Where(e => e.Id == idExpediente).SingleOrDefault();
        if ( expediente != null )
        {
            if (expediente.Tramites != null && expediente.Tramites.Any())
            {
            db.RemoveRange(expediente.Tramites);
             }
        db.Remove(expediente);
        db.SaveChanges();
        }else{
            throw new RepositorioException($"No se encontro Expediente Id{idExpediente}");
        }
    }

    public Expediente? ConsultaPorId(int id)
    {
        using var db = new DataContext(); 
        return db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    
    }

    public Expediente? ConsultarExpedienteYTramites(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public LinkedList<Expediente> ConsultarTodos()
    {
        throw new NotImplementedException();
    }

    public void Crear(int idUsuario)
    {
        throw new NotImplementedException();
    }

    public void ModificarExpediente(Expediente expediente)
    {
        throw new NotImplementedException();
    }
    // private void chequeo(){
    //      if(!File.Exists(_archivo))
    //      {
    //          throw new RepositorioException("No Se encuentra Expediente.txt");
    //      }
    //  }
    //  public void AltaExpediente(Expediente expediente, int? idUsuario)
    //  {
    //      try
    //      {
    //          chequeo();
    //          using (StreamWriter writer = new StreamWriter(_archivo, true))
    //          {
    //              writer.WriteLine(expediente);
    //          }
    //      }
    //      catch (Exception e)
    //      {
    //          Console.WriteLine($"{e.Message}");
    //      }
    //  }
    //  public void BajaExpediente(int idExpediente, int idUsuario)
    //  {
    //     try
    //      {
    //          chequeo();
    //          LinkedList<string> expedientes = new LinkedList<string>(); 
    //          using(StreamReader reader = new StreamReader(_archivo))
    //          {
    //              while(!reader.EndOfStream)
    //              {
    //                  string linea = reader.ReadLine()??"";
    //                  string[] scrap = linea.Split("\t"); 
    //                  if(!(scrap[0] == idExpediente.ToString())){
    //                      expedientes.AddLast(linea);
    //                  }
    //                  else
    //                  {
    //                      TR.EliminarPorIdRegistro(scrap[0]);
    //                      //LLamar Metodo Para eliminar Sus Tramites;
    //                  }
    //              }
    //          }
    //          using(StreamWriter writer = new StreamWriter(_archivo))
    //          {
    //              foreach(string expediente in expedientes)
    //              {    
    //                      writer.WriteLine(expediente);
    //              }
    //          }


    //      }
    //      catch (Exception e)
    //      {
    //          Console.WriteLine($"{e.Message}");
    //      }
    //  }

    //  public Expediente? ConsultaPorId(int idExpediente)
    //  {
    //      try
    //      {
    //          chequeo();
    //          using(StreamReader reader = new StreamReader(_archivo))
    //          {
    //              while(!reader.EndOfStream)
    //              {
    //                  string line = reader.ReadLine()??"";
    //                  if(line.Split("\t")[0] == idExpediente.ToString())
    //                  {
    //                      Expediente e = Expediente.Ensamblado(line);
    //                      return e;
    //                  }
    //              }
    //              throw new Exception("No se encontro un Expediente con ese ID");
    //          }
    //      }
    //      catch(Exception e)
    //      {
    //          Console.WriteLine($"{e.Message}");
    //          return null;
    //      }
    //  }

    //  public Expediente? ConsultarExpedienteYTramites (int idExpediente)
    //  {
    //      Expediente? retorno = null;
    //      try
    //      {
    //      chequeo();
    //      //Debe actualizarse con dataBase
    //      using(StreamReader reader = new StreamReader(_archivo))
    //      {
    //          while(!reader.EndOfStream)
    //          {
    //              string line = reader.ReadLine()??"";
    //              if(line.Split("\t")[0] == idExpediente.ToString())
    //              {
    //                  retorno  = Expediente.Ensamblado(line);
    //                  //Llamado a la base de datos
    //              }
    //          }
    //      }
    //      return retorno;
    //      } 
    //      catch
    //      {
    //          return retorno;
    //      }
    //  }

    //  public LinkedList<Expediente> ConsultarTodos()
    //  {
    //      LinkedList<Expediente> expedientes =  new LinkedList<Expediente>(); 
    //      try
    //      {
    //          chequeo();
    //          using(StreamReader reader = new StreamReader(_archivo))
    //          {
    //              while(!reader.EndOfStream)
    //              {
    //                  expedientes.AddLast(Expediente.Ensamblado(reader.ReadLine()?? ""));
    //              }
    //          }
    //          return expedientes;
    //      }
    //      catch(Exception e)
    //      {
    //          Console.WriteLine($"{e.Message}");
    //          return expedientes;
    //      }
    //  }

    //  public void Crear(int idUsuario)
    //  {
    //      try
    //      {
    //          File.Create(_archivo).Close();
    //      }
    //      catch ( RepositorioException e)
    //      {
    //          Console.WriteLine(e.Message);
    //      }
    //  }

    //  //Asumo que Ya viene modificado
    //  public void ModificarExpediente(Expediente expediente,  int? idUsuario)
    //  {
    //      try
    //      {
    //        chequeo();
    //        LinkedList<string> elementos = new LinkedList<string>();
    //        using(StreamReader reader = new StreamReader(_archivo))
    //        {
    //          while(!reader.EndOfStream)
    //          {
    //              string linea = reader.ReadLine()??""; 
    //              if(linea.Split("\t")[0] == expediente.ToString().Split("\t")[0])
    //              {
    //                  elementos.AddLast(expediente.ToString());
    //              }
    //              else
    //              {
    //                  elementos.AddLast(linea);
    //              }
    //          }
    //        }
    //        using(StreamWriter writer = new StreamWriter(_archivo))
    //        {
    //          foreach(string elem in elementos)
    //          {
    //              writer.WriteLine(elem); 
    //          }
    //        }

    //      }
    //      catch(Exception e)
    //      {
    //          Console.WriteLine($"{e.Message}");
    //      }
    //  }
    //  private void chequeo(){
    //      if(!File.Exists(_archivo))
    //      {
    //          throw new RepositorioException("No Se encuentra Expediente.txt");
    //      }
    //  }
}
