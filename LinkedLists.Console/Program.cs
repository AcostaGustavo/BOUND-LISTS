using DoubleList;

var list = new DoubleLinkedList<string>();

string option;
string value;

do
{
    Console.WriteLine("\n===== MENU =====");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show back");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Delete an occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");

    Console.Write("Select the option: ");
    option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":

            Console.Write("Enter value: ");
            value = Console.ReadLine() ?? "";

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

            list.ShowForward();

            break;

        case "5":

            list.ShowModes();

            break;

        case "6":

            list.ShowGraph();

            break;

        case "7":

            Console.Write("Enter value: ");
            value = value = Console.ReadLine() ?? "";

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
            value = Console.ReadLine() ?? "";

            if (list.Exists(value))
            {
                list.Remove(value);

                Console.WriteLine("Element removed.");
            }
            else
            {
                Console.WriteLine("Does not exist.");
            }

            break;

        case "9":

            Console.Write("Enter value: ");
            value = Console.ReadLine() ?? "";

            if (list.Exists(value))
            {
                list.RemoveAll(value);

                Console.WriteLine("All occurrences removed.");
            }
            else
            {
                Console.WriteLine("Does not exist.");
            }

            break;
    }

} while (option != "0");