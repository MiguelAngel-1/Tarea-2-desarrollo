public interface IMensaje
{
    string getContenido();
}
public class Mensaje : IMensaje
{
    public string _contenido;
    public Mensaje(string contenido)
    {
        _contenido = contenido;
    }
    public string getContenido()
    {
        return _contenido;
    }
}
public abstract class MensajeDecorador : IMensaje
{
    public IMensaje _mensaje;
    public MensajeDecorador(IMensaje mensaje)
    {
        _mensaje = mensaje;
    }
    public virtual string getContenido()
    {
        return _mensaje.getContenido();
    }
}
public class EncriptarMensaje : MensajeDecorador
{
    public EncriptarMensaje(IMensaje mensaje) : base(mensaje) { }
    public override string getContenido()
    {
        return $"Encriptado {_mensaje.getContenido()}";
    }
}
public class ComprimirMensaje : MensajeDecorador
{
    public ComprimirMensaje(IMensaje mensaje) : base(mensaje) { }
    public override string getContenido()
    {
        return $"Comprimido y {_mensaje.getContenido()}";
    }
}
public class FirmarMensaje : MensajeDecorador
{
    public FirmarMensaje(IMensaje mensaje) : base(mensaje) { }
    public override string getContenido()
    {
        return $"Firmado, {_mensaje.getContenido()}";
    }
}
public class Program
{
    public static void Main()
    {
        IMensaje mensaje = new Mensaje("el mensaje inicial");
        Console.WriteLine(mensaje.getContenido());
        mensaje = new EncriptarMensaje(mensaje);
        Console.WriteLine(mensaje.getContenido());
        mensaje = new ComprimirMensaje(mensaje);
        Console.WriteLine(mensaje.getContenido());
        mensaje = new FirmarMensaje(mensaje);
        Console.WriteLine(mensaje.getContenido());
    }
}
