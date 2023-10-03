using System;
using System.Collections.Generic;

public abstract class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Identificacion { get; set; }
}

public class Ciudadano : Persona
{
    public int IdCiudadano { get; set; }
    public List<Incidente> Incidentes { get; set; }
}

public class Incidente
{
    public int IdIncidente { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public CategoriaIncidente Categoria { get; set; }
    public UbicacionGeografica Ubicacion { get; set; }
    public string Estatus { get; set; }
}

public enum CategoriaIncidente
{
    Robo,
    Fraude,
    Corrupcion,
    Otro
}

public class UbicacionGeografica
{
    public double Latitud { get; set; }
    public double Longitud { get; set; }
}

public interface INotificable
{
    void EnviarNotificacion(string mensaje);
}

public class Notificador : INotificable
{
    public void EnviarNotificacion(string mensaje)
    {
        Console.WriteLine("Notificación enviada: " + mensaje);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Incidente> incidentes = new List<Incidente>();
        int incidenteId = 1;

        while (true)
        {
            Console.WriteLine("1. Registrar un incidente");
            Console.WriteLine("2. Ver lista de incidentes");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Descripción del incidente: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Categoría (0: Robo, 1: Fraude, 2: Corrupción, 3: Otro): ");
                        if (Enum.TryParse(Console.ReadLine(), out CategoriaIncidente categoria))
                        {
                            Console.Write("Latitud: ");
                            if (double.TryParse(Console.ReadLine(), out double latitud))
                            {
                                Console.Write("Longitud: ");
                                if (double.TryParse(Console.ReadLine(), out double longitud))
                                {
                                    var incidente = new Incidente
                                    {
                                        IdIncidente = incidenteId++,
                                        Descripcion = descripcion,
                                        Fecha = DateTime.Now,
                                        Categoria = categoria,
                                        Ubicacion = new UbicacionGeografica { Latitud = latitud, Longitud = longitud },
                                        Estatus = "Pendiente"
                                    };

                                    incidentes.Add(incidente);
                                    Console.WriteLine("Incidente registrado con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("Latitud no válida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Longitud no válida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Categoría no válida.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Lista de incidentes registrados:");
                        foreach (var i in incidentes)
                        {
                            Console.WriteLine($"ID: {i.IdIncidente}, Descripción: {i.Descripcion}, Categoría: {i.Categoria}, Fecha: {i.Fecha}");
                        }
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.WriteLine();
        }
    }
}
