using SistemaComunidad;


Docente miProfe = new Docente
{
    Nombre = "Ing. Starlyn (el jefe)",
    Especialidad = "Joseador del genero.",
    Salario = 5000
};

miProfe.Presentarse();
Console.WriteLine($"Especialidad: {miProfe.Especialidad}, Salario: ${miProfe.Salario}");

Console.WriteLine("\nPresiona cualquier tecla para salir...");
Console.ReadKey();