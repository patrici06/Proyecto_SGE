namespace Repositorios;

using System.Runtime.CompilerServices;
using Aplicacion;

public class TramitesRepositorio(string arch): ITramiteRepositorio
{
    readonly string _archivo = arch;

    public void AgregarRegistro(Tramite tramite, int idUsuario)
    {
        try
        {   
            if(!File.Exists(_archivo))
            {
                throw new RepositorioException($"NO Existe {_archivo}");
            }
            using (StreamWriter writer = new StreamWriter(_archivo, true))
            {
                 writer.WriteLine(tramite);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    public void Crear(int idUsuario)
    {
        try
        {
            if(File.Exists(_archivo)){

            }
            File.Create(_archivo).Close();
        }
        catch ( AutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ElimiarRegistro(int idTramite, int idUsuario)
    {
        try
        {            
            LinkedList<string> tramites = new LinkedList<string>(); 
            using(StreamReader reader = new StreamReader(_archivo))
            {
                while(!reader.EndOfStream)
                {
                    string linea = reader.ReadLine()??"";
                    string[] scrap = linea.Split("\t"); 
                    if(scrap[0] != idTramite.ToString()){
                        tramites.AddLast(linea);
                    }
                }
            }
            using(StreamWriter writer = new StreamWriter(_archivo))
            {
                foreach(string tramite in tramites)
                {    
                        writer.WriteLine(tramite);
                }
            writer.Close();
            }


        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    // EL METODO RECIBE EL TRAMITE MODIFICADO Y LO SOBREESCRIBE
    public void ModificarRegistro(Tramite tramite, int idUsuario)
    {
        try
        {
          if(!File.Exists(_archivo))
          {
            throw new RepositorioException($" No existe {_archivo}"); 
          }
          LinkedList<string> tramites = new LinkedList<string>();
          using(StreamReader reader = new StreamReader(_archivo))
          {
            while(!reader.EndOfStream)
            {
                string linea = reader.ReadLine()??""; 
                if(linea.Split("\t")[0] == tramite.ToString().Split("\t")[0])
                {
                    tramites.AddLast(tramite.ToString());
                }
                else
                {
                    tramites.AddLast(linea);
                }
            }
            reader.Close();
          }
          using(StreamWriter writer = new StreamWriter(_archivo))
          {
            foreach(string elem in tramites)
            {
                writer.WriteLine(elem); 
            }
            writer.Close();
          }

        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }


    //Metodos extra a la interfaz 
    public LinkedList<Tramite> ConsultarTramitesExpedientes(int idExpediente)
    {
    LinkedList<Tramite> retorno = new LinkedList<Tramite>();
     try
     {
        if(!File.Exists(_archivo))
          {
            throw new RepositorioException($" No existe {_archivo}"); 
          }
        using(StreamReader reader =  new StreamReader(_archivo))
        {
            while(!reader.EndOfStream){
                string line =reader.ReadLine()??"";
             if(idExpediente.ToString() == line.Split("\t")[1])
             {
                retorno.AddLast(Tramite.Ensamblador(line));
             }
            }
            reader.Close();
        }
        return retorno;
     } 
     catch(Exception e )
     {
        Console.WriteLine($"{e.Message}");
        return retorno;
     }
    }
    public void EliminarPorIdRegistro(string idExpediente)
    {
        try
        {   
            if(!File.Exists(_archivo))
            {
            throw new RepositorioException($" No existe {_archivo}"); 
            }
            LinkedList<string> salvado = new LinkedList<string>();
            using(StreamReader reader = new StreamReader(_archivo))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine()??"";
                    if(idExpediente != line.Split("\t")[1])
                    {
                       salvado.AddLast(line); 
                    }
                }
            reader.Close();
            }
            using(StreamWriter writer = new StreamWriter(_archivo))
            {
                foreach(string dato in salvado)
                {
                    writer.WriteLine(dato);
                }
            writer.Close();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
    public Tramite? ConsultaPorId(int idTramite)
    {
        try
        {
            if(!File.Exists(_archivo)){ throw new RepositorioException("no se encontro el archivo");}
            Tramite? tramite = null;
            using (StreamReader reader = new StreamReader(_archivo))
            {
                string linea =  reader.ReadLine()??""; 
                if(idTramite.ToString() == linea.Split("\t")[0])
                {
                    tramite = Tramite.Ensamblador(linea);
                }
            }
            return tramite;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
            return null; 
        }
    }
    public LinkedList<Tramite> ConsultaPorEtiqueta(EstadoTramite estado)
    {
        LinkedList<Tramite> tramites = new LinkedList<Tramite>();
        try
        {
            if(!File.Exists(_archivo))
            {
            throw new RepositorioException($" No existe {_archivo}"); 
            }
            using(StreamReader reader = new StreamReader(_archivo))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine() ?? "";
                    string[] partes = line.Split("\t");

                    if(partes[6] == estado.ToString())
                    {
                        tramites.AddLast(Tramite.Ensamblador(line));
                    }
                }

                return tramites;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}");
            return tramites;
        }
    }
}
