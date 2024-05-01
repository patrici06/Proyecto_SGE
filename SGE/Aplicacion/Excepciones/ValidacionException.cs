namespace Aplicacion;

public class ContenidoException : Exception {
    public string contenidoException{get; private set;}
    public ContenidoException(string message, string type):base(message) 
    {
        contenidoException = type;
    }
    public ContenidoException(string message, string type, Exception innerException): base(message, innerException)
    {   
        contenidoException = type;
    }    
}

public class ValidacionException : Exception {
    public ValidacionException(string mensaje) : base(mensaje)
    {
    }
}