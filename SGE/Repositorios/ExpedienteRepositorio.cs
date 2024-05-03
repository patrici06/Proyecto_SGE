namespace Repositorios;

using System.Collections;
using Aplicacion;

public class ExpedienteRepositorios(ServicioAutorizacionProvisorio SA, ExpedienteValidador EV, TramitesRepositorio TR): IExpedienteRepositorios
{
    readonly string _archivo = "Expedientes.txt";
    public void AltaExpediente(Expediente expediente, int idUsuario)
    {
        try
        {
            chequeo();
            if (!SA.PoseeElPermiso(idUsuario)){
                throw new AutorizacionException("No Posee los permisos necesarios");
            }
            EV.ValidarExpediente(expediente);
             using (StreamWriter writer = new StreamWriter(_archivo, true))
            {
                 writer.WriteLine(expediente);
                 writer.Close();
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
            if(!SA.PoseeElPermiso(idUsuario))
            {
                throw new ValidacionException("No Posee Permisos");
            }
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
            writer.Close();
            }


        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Data}{e.Message}");
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
                  //tramites = TR.ConsultarTramitesExpedientes(idExpediente);
                }
            }
            reader.Close();
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
            reader.Close();
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
            reader.Close();
          }
          using(StreamWriter writer = new StreamWriter(_archivo))
          {
            foreach(string elem in elementos)
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
    private void chequeo(){
        if(!File.Exists(_archivo))
        {
            throw new RepositorioException("No Se encuentra Expediente.txt");
        }
    }
}
