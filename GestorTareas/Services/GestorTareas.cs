
using System.Text.Json;
using System.Text.Json.Serialization;

public class GestorTareas
{
    private List<Tarea> tareas = new List<Tarea>();
    private const string RutaJson = "Data/tareas.json";
    public GestorTareas()
    {
        CargarTareas();
    }


    public void AñadirTarea()
    {
        Tarea nueva = new Tarea();
        string completada = " ";
        Console.WriteLine("Título:");
        nueva.Titulo = Console.ReadLine();
        Console.WriteLine("Descripción: ");
        nueva.Descripcion = Console.ReadLine();
        Console.WriteLine("¿Está completada? Y/N");
        completada = Console.ReadLine();
        nueva.Completada = completada?.Trim().ToLower() == "y";
        Console.WriteLine("La tarea nueva es: " + nueva.Titulo + "\nLa descripción es: " + nueva.Descripcion);
        tareas.Add(nueva);
        GuardarTareas();
    }

    public void VerTareas()
    {
        int index = 1;
        foreach (Tarea tarea in tareas)
        {
            Console.WriteLine("\n");
            Console.WriteLine("    ===== TAREA " + index + " =====");
            Console.WriteLine("|   Título: " + tarea.Titulo);
            Console.WriteLine("|   Descripción: " + tarea.Descripcion);
            Console.Write("|   Completada: ");
            if (tarea.Completada == true)
            {
                Console.Write("sí");
            }
            else
            {
                Console.Write("no");
            }
            Console.WriteLine("\n");
            index++;
        }
    }

    public void VerTareasSinCompletar()
    {
        int index = 1;
        foreach (Tarea tarea in tareas)
        {
            if (!tarea.Completada)
            {
                Console.WriteLine("\n");
            Console.WriteLine("    ===== TAREA " + index + " =====");
            Console.WriteLine("|   Título: " + tarea.Titulo);
            Console.WriteLine("|   Descripción: " + tarea.Descripcion);
            }
            index++;
        }
    }

    public void CambiarEstadoTarea()
    {
        Console.WriteLine("¿Qué tarea quieres modificar?");
        VerTareas();
        string elegida = Console.ReadLine();
        if (!int.TryParse(elegida, out int opcion))
        {
            Console.WriteLine("Debes introducir un número.");
            return;
        }

        if (opcion < 1 || opcion > tareas.Count)
        {
            Console.WriteLine("Esa tarea no existe");
            return;
        }
        opcion--;

        tareas[opcion].Completada = !tareas[opcion].Completada;
        GuardarTareas();

        if (tareas[opcion].Completada)
        {
            Console.WriteLine("La tarea se ha marcado como completada.");
        }
        else
        {
            Console.WriteLine("La tarea se ha marcado como pendiente.");
        }
        
    }

    public void GuardarTareas()
    {
        string json = JsonSerializer.Serialize(tareas);
        File.WriteAllText(RutaJson, json);
    }

    public void CargarTareas()
    {

        if (File.Exists(RutaJson))
        {
            string json = File.ReadAllText(RutaJson);
            tareas = JsonSerializer.Deserialize<List<Tarea>>(json) ?? new List<Tarea>();
        }
        else
        {
            Console.WriteLine("No existe");
        }

    }
}