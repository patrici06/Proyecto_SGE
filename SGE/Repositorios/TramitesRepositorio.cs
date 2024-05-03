namespace Repositorios; 
using Aplicacion;

public class TramitesRepositorio(ServicioAutorizacionProvisorio SA, TramiteValidador TV): ITramiteRepositorio
{
    readonly string _archivo = "tramites.txt";

    public void AgregarRegistro(Tramite tramite, int idUsuario)
    {
        try
        {
            chequeo();
            if (!SA.PoseeElPermiso(idUsuario)){
                throw new AutorizacionException("No Posee los permisos necesarios");
            }
            TV.ValidarTramite(tramite);
            using (StreamWriter writer = new StreamWriter(_archivo, true))
            {
                 writer.WriteLine(tramite);
                 writer.Close();
             }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Data}, {e.Message}");
        }
    }

    public void Crear(int idUsuario)
    {
        try
        {
            if(!SA.PoseeElPermiso(idUsuario))
            {
                throw new AutorizacionException("No posee Permisos");
            }
            File.Create(_archivo);
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
            chequeo();
            if(!SA.PoseeElPermiso(idUsuario))
            {
                throw new ValidacionException("No Posee Permisos");
            }
            
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
            Console.WriteLine($"{e.Data}{e.Message}");
        }
    }

    // EL METODO RECIBE EL TRAMITE MODIFICADO Y LO SOBREESCRIBE
    public void ModificarRegistro(Tramite tramite, int idUsuario)
    {
        try
        {
          chequeo();
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
            Console.WriteLine($"{e.Data},{e.Message}");
        }
    }


    //Metodos extra a la interfaz 
    public LinkedList<Tramite> ConsultarTramitesExpedientes(int idExpediente)
    {
    LinkedList<Tramite> retorno = new LinkedList<Tramite>();
     try
     {
        chequeo();
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
        Console.WriteLine($"{e.Data},{e.Message}");
        return retorno;
     }
    }
    public void EliminarPorIdRegistro(string idExpediente)
    {
        try
        {   
            chequeo();
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
            Console.WriteLine($"{e.Data}{e.Message}");
        }
    }
     private  void chequeo(){
        if(!File.Exists(_archivo))
        {
            throw new RepositorioException("No Se encuentra Tramite.txt");
        }
    }

    public LinkedList<Tramite> ConsultaPorEtiqueta(EstadoTramite estado)
    {
        LinkedList<Tramite> tramites = new LinkedList<Tramite>();
        try
        {
            chequeo();
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
            Console.WriteLine($"{e.Data}{e.Message}");
            return tramites;
        }
    }
}
