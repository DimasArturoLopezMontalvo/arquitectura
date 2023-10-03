using System;
using System.Collections.Generic;

public abstract class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Identificacion { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
}

public class Ciudadano : Persona
{
    public int IdCiudadano { get; set; }
    public List<Incidente> Incidentes { get; set; }
    public string CURP { get; set; }
}

public class ServidorPublico : Persona
{
    public int IdServidorPublico { get; set; }
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
    public string CodigoPostal { get; set; }
    public string Municipio { get; set; }
    public string Estado { get; set; }
    public string Ciudad { get; set; }
    public string Region { get; set; }
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
        List<Ciudadano> ciudadanos = new List<Ciudadano>();
        List<ServidorPublico> servidoresPublicos = new List<ServidorPublico>();
        int incidenteId = 1;
        int ciudadanoId = 1;
        int servidorPublicoId = 1;

        while (true)
        {
            Console.WriteLine("Bienvenido al sistema de reporte de incidentes:");
            Console.WriteLine("1. Registrar un incidente");
            Console.WriteLine("2. Ver lista de incidentes");
            Console.WriteLine("3. Registrarse como ciudadano");
            Console.WriteLine("4. Registrarse como servidor público");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        // Código para registrar un incidente
                        Console.Write("Descripción del incidente: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Categoría (0: Robo, 1: Fraude, 2: Corrupción, 3: Otro): ");
                        if (Enum.TryParse(Console.ReadLine(), out CategoriaIncidente categoria))
                        {
                            var ubicacion = new UbicacionGeografica();

                            Console.Write("Código Postal: ");
                            ubicacion.CodigoPostal = Console.ReadLine();

                            Console.Write("Municipio: ");
                            ubicacion.Municipio = Console.ReadLine();

                            Console.Write("Estado: ");
                            ubicacion.Estado = Console.ReadLine();

                            Console.Write("Ciudad: ");
                            ubicacion.Ciudad = Console.ReadLine();

                            Console.Write("Región: ");
                            ubicacion.Region = Console.ReadLine();

                            var incidente = new Incidente
                            {
                                IdIncidente = incidenteId++,
                                Descripcion = descripcion,
                                Fecha = DateTime.Now,
                                Categoria = categoria,
                                Ubicacion = ubicacion,
                                Estatus = "Pendiente"
                            };

                            incidentes.Add(incidente);
                            Console.WriteLine("Incidente registrado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Categoría no válida.");
                        }
                        break;

                    case 2:
                        // Código para ver la lista de incidentes
                        Console.WriteLine("Lista de incidentes registrados:");
                        foreach (var i in incidentes)
                        {
                            Console.WriteLine($"ID: {i.IdIncidente}, Descripción: {i.Descripcion}, Categoría: {i.Categoria}, Fecha: {i.Fecha}");
                            Console.WriteLine($"Ubicación: Código Postal: {i.Ubicacion.CodigoPostal}, Municipio: {i.Ubicacion.Municipio}, Estado: {i.Ubicacion.Estado}, Ciudad: {i.Ubicacion.Ciudad}, Región: {i.Ubicacion.Region}");
                        }
                        break;

                    case 3:
                        // Registro de ciudadano
                        Console.Write("Nombre: ");
                        string nombreCiudadano = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string apellidoCiudadano = Console.ReadLine();
                        Console.Write("CURP: ");
                        string curpCiudadano = Console.ReadLine();
                        Console.Write("Correo: ");
                        string correoCiudadano = Console.ReadLine();
                        Console.Write("Contraseña: ");
                        string contraseñaCiudadano = Console.ReadLine();

                        var ciudadano = new Ciudadano
                        {
                            IdCiudadano = ciudadanoId++,
                            Nombre = nombreCiudadano,
                            Apellido = apellidoCiudadano,
                            CURP = curpCiudadano,
                            Correo = correoCiudadano,
                            Contraseña = contraseñaCiudadano,
                            Incidentes = new List<Incidente>()
                        };

                        ciudadanos.Add(ciudadano);
                        Console.WriteLine("Ciudadano registrado con éxito.");
                        break;

                    case 4:
                        // Registro de servidor público
                        Console.Write("Nombre: ");
                        string nombreServidorPublico = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string apellidoServidorPublico = Console.ReadLine();
                        Console.Write("ID de Servidor Público: ");
                        string idServidorPublico = Console.ReadLine();
                        Console.Write("Correo: ");
                        string correoServidorPublico = Console.ReadLine();
                        Console.Write("Contraseña: ");
                        string contraseñaServidorPublico = Console.ReadLine();

                        var servidorPublico = new ServidorPublico
                        {
                            IdServidorPublico = servidorPublicoId++,
                            Nombre = nombreServidorPublico,
                            Apellido = apellidoServidorPublico,
                            Identificacion = idServidorPublico,
                            Correo = correoServidorPublico,
                            Contraseña = contraseñaServidorPublico
                        };

                        servidoresPublicos.Add(servidorPublico);
                        Console.WriteLine("Servidor público registrado con éxito.");
                        break;

                    case 5:
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
