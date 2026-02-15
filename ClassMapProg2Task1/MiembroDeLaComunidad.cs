namespace SistemaComunidad;

public abstract class MiembroDeLaComunidad
{
    public string Nombre { get; set; }
    public virtual void Presentarse() => Console.WriteLine($"Soy {Nombre}, miembro de la comunidad.");
}