namespace Repositorios;

using System.Collections;
using Aplicacion;

public class ExpedienteRepositorio(TramitesRepositorio TR, string arch): IExpedienteRepositorio
{
    readonly string _archivo = arch;
    public void AltaExpediente(Expediente expediente, int idUsuario)
    {
        try
        {
            chequeo();
            using (StreamWriter writer = new StreamWriter(_archivo, true))
            {
                writer.WriteLine(expediente);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Data}, {e.Message}");
        }
    }
    public void BajaExpediente(int idExpediente, int idUsuario)
    {
       try
        {
            chequeo();
            LinkedList<string> expedientes = new LinkedList<string>(); 
            using(StreamReader reader = new StreamReader(_archivo))
            {
                while(!reader.EndOfStream)
                {
                    string linea = reader.ReadLine()??"";
                    string[] scrap = linea.Split("\t"); 
                    if(!(scrap[0] == idExpediente.ToString())){
                        expedientes.AddLast(linea);
                    }
                    else
                    {
                        TR.EliminarPorIdRegistro(scrap[0]);
                        //LLamar Metodo Para eliminar Sus Tramites;
                    }
                }
            }
            using(StreamWriter writer = new StreamWriter(_archivo))
            {
                foreach(string expediente in expedientes)
                {    
                        writer.WriteLine(expediente);
                }
            }


        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Data}{e.Message}");
        }
    }

    public Expediente? ConsultaPorId(int idExpediente)
    {
        try
        {
            chequeo();
            using(StreamReader reader = new StreamReader(_archivo))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine()??"";
                    if(line.Split("\t")[0] == idExpediente.ToString())
                    {
                        Expediente e = Expediente.Ensamblado(line);
                        return e;
                    }
                }
                throw new Exception("No se encontro un Expediente con ese ID");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Data}, {e.Message}");
            return null;
        }
    }

    public LinkedList<Tramite> ConsultarExpedienteYTramites (out Expediente? retorno, int idExpediente)
    {
        retorno = null; 
        LinkedList<Tramite> tramites = new LinkedList<Tramite>();
        try
        {
        chequeo();
        using(StreamReader reader = new StreamReader(_archivo))
        {
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine()??"";
                if(line.Split("\t")[0] == idExpediente.ToString())
                {
                    retorno  = Expediente.Ensamblado(line);
                    tramites = TR.ConsultarTramitesExpedientes(idExpediente);
                }
            }
        }
        return tramites;
        } 
        catch (Exception e)
        {
            Console.WriteLine($"{e.Data}, {e.Message}");
            return tramites;
        }
    }

    public LinkedList<Expediente> ConsultarTodos()
    {
        LinkedList<Expediente> expedientes =  new LinkedList<Expediente>(); 
        try
        {
            chequeo();
            using(StreamReader reader = new StreamReader(_archivo))
            {
                while(!reader.EndOfStream)
                {
                    expedientes.AddLast(Expediente.Ensamblado(reader.ReadLine()?? ""));
                }
            }
            return expedientes;
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Data}{e.Message}");
            return expedientes;
        }
    }

    public void Crear(int idUsuario)
    {
        try
        {
            File.Create(_archivo);
        }
        catch ( RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    //Asumo que Ya viene modificado
    public void ModificarExpediente(Expediente expediente,  int idUsuario)
    {
        try
        {
          chequeo();
          LinkedList<string> elementos = new LinkedList<string>();
          using(StreamReader reader = new StreamReader(_archivo))
          {
            while(!reader.EndOfStream)
            {
                string linea = reader.ReadLine()??""; 
                if(linea.Split("\t")[0] == expediente.ToString().Split("\t")[0])
                {
                    elementos.AddLast(expediente.ToString());
                }
                else
                {
                    elementos.AddLast(linea);
                }
            }
          }
          using(StreamWriter writer = new StreamWriter(_archivo))
          {
            foreach(string elem in elementos)
            {
                writer.WriteLine(elem); 
            }
          }

        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Data},{e.Message}");
        }
    }
    private void chequeo(){
        if(!File.Exists(_archivo))
        {
            throw new RepositorioException("No Se encuentra Expediente.txt");
        }
    }
}
