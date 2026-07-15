
GestorTareas gestor = new GestorTareas();
int opcion = 0;
do
{
    ImprimirMenu();
    string entrada = Console.ReadLine();

            //Convertir texto a entero
    if (!int.TryParse(entrada, out opcion))
{
    Console.WriteLine("Debes introducir un número.");
    continue;
}

    switch (opcion)
    {
        case 1:
            gestor.AñadirTarea();
            break;
        case 2:
            gestor.VerTareas();
            break;
        case 3:
            gestor.CambiarEstadoTarea();
            break;
        case 4:
            gestor.VerTareasSinCompletar();
            break;
        case 5:
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
} while (opcion != 5);


void ImprimirMenu()
{
    Console.WriteLine("========== GESTOR DE TAREAS ===========");
    Console.WriteLine("||   1. Añadir tarea                 ||");
    Console.WriteLine("||   2. Ver tareas                   ||");
    Console.WriteLine("||   3. Cambiar estado de una tarea  ||");
    Console.WriteLine("||   4. Ver tareas sin completar     ||");
    Console.WriteLine("||   5. Salir                        ||");
    Console.WriteLine("||   Elige una opción                ||");
    Console.WriteLine("=======================================");

}
