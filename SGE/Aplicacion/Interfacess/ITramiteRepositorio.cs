namespace Repositorios;
using Aplicacion;
public interface ITramiteRepositorio
{
    static void Crear(Tramite tramite){}
    static void AgregarRegistro(Tramite tipo){} 
    static void ModificarRegistro(Tramite tipo){}
    static void ElimiarRegistro(Tramite tipo){}
}