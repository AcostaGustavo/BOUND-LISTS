using DoubleList;
using System.Collections;

var list = new DoubleLinkedList<int>();

string option;
int value;

do
{
    Console.WriteLine("\n===== MENU =====");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");

    Console.Write("Option: ");
    option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":

            Console.Write("Enter value: ");
            value = int.Parse(Console.ReadLine()!);

            list.InsertOrdered(value);

            break;

        case "2":

            list.ShowForward();

            break;

        case "3":

            list.ShowBackward();

            break;

        case "4":

            list.SortDescending();

            Console.WriteLine("List sorted descending.");

            break;

        case "5":

            list.ShowModes();

            break;

        case "6":

            list.ShowGraph();

            break;

        case "7":

            Console.Write("Enter value: ");
            value = int.Parse(Console.ReadLine()!);

            bool exists = list.Exists(value);

            if (exists)
            {
                Console.WriteLine("Value exists in the list.");
            }
            else
            {
                Console.WriteLine("Value does not exist.");
            }

            break;

        case "8":

            Console.Write("Enter value: ");
            value = int.Parse(Console.ReadLine()!);

            list.Remove(value);

            Console.WriteLine("Element removed.");

            break;

        case "9":

            Console.Write("Enter value: ");
            value = int.Parse(Console.ReadLine()!);

            list.RemoveAll(value);

            Console.WriteLine("All occurrences removed.");

            break;
    }

} while (option != "0");