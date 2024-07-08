using System.Security.Cryptography;
using System.Text;

namespace SGE.Aplicacion;

public class ServicioHash 
{

    public  bool validarContrasena(string contrasena, string contra)
    {
        string hashContrasena = generarHashContrasena(contrasena);
            if(hashContrasena == contra)
                return true;
            else
                return false;
    }
    public  string generarHashContrasena(string contrasena)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(contrasena);
        using (var sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashString;
        }
    }
}