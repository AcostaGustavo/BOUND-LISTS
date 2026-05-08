using Shared;
using System.Collections.Generic;

namespace DoubleList;

public class DoubleLinkedList<T>
    where T : IComparable<T>
{
    private Node<T>? head;
    private Node<T>? tail;

    public void InsertOrdered(T data)
    {
        var newNode = new Node<T>(data);

        // LISTA VACÍA
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            return;
        }

        var current = head;

        // INSERTAR AL INICIO
        if (data.CompareTo(head.Data) < 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;

            return;
        }

        // BUSCAR POSICIÓN
        while (current.Next != null &&
               current.Next.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        // INSERTAR AL FINAL
        if (current.Next == null)
        {
            current.Next = newNode;
            newNode.Previous = current;
            tail = newNode;

            return;
        }

        // INSERTAR EN EL MEDIO
        newNode.Next = current.Next;
        newNode.Previous = current;

        current.Next.Previous = newNode;
        current.Next = newNode;
    }

    public void ShowForward()
    {
        var current = head;

        while (current != null)
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        }

        Console.WriteLine("NULL");
    }

    public void ShowBackward()
    {
        var current = tail;

        while (current != null)
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Previous;
        }

        Console.WriteLine("NULL");
    }

    public bool Exists(T data)
    {
        var current = head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void Remove(T data)
    {
        if (head == null)
        {
            return;
        }

        var current = head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                // ELIMINAR CABEZA
                if (current == head)
                {
                    head = current.Next;

                    if (head != null)
                    {
                        head.Previous = null;
                    }
                    else
                    {
                        tail = null;
                    }
                }

                // ELIMINAR LA COLA
                else if (current == tail)
                {
                    tail = current.Previous;

                    if (tail != null)
                    {
                        tail.Next = null;
                    }
                }

                // ELIMINAR EN MEDIOL
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }

                return;
            }

            current = current.Next;
        }
    }
    public void RemoveAll(T data)
    {
        var current = head;

        while (current != null)
        {
            var nextNode = current.Next;

            if (current.Data!.Equals(data))
            {
                // SI ES EL PRIMER NODO
                if (current == head)
                {
                    head = head.Next;

                    if (head != null)
                    {
                        head.Previous = null;
                    }
                    else
                    {
                        tail = null;
                    }
                }

                // SI ES EL ÚLTIMO
                else if (current == tail)
                {
                    tail = tail.Previous;

                    if (tail != null)
                    {
                        tail.Next = null;
                    }
                }

                // SI ESTÁ EN EL MEDIO
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
            }

            current = nextNode;
        }
    }
    public void SortDescending()
    {
        if (head == null)
        {
            return;
        }

        bool swapped;

        do
        {
            swapped = false;

            var current = head;

            while (current != null && current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) < 0)
                {
                    // INTERCAMBIAR DATOS
                    T temp = current.Data;

                    current.Data = current.Next.Data;

                    current.Next.Data = temp;

                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
    }

    public void ShowModes()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Dictionary<T, int> frequencies = new();

        var current = head;

        // CONTAR FRECUENCIAS
        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
            {
                frequencies[current.Data]++;
            }
            else
            {
                frequencies[current.Data] = 1;
            }

            current = current.Next;
        }

        // ENCONTRAR FRECUENCIA MÁXIMA
        int maxFrequency = frequencies.Values.Max();

        Console.WriteLine("Mode(s):");

        // MOSTRAR MODAS
        foreach (var item in frequencies)
        {
            if (item.Value == maxFrequency)
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
        }
    }

    public void ShowGraph()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Dictionary<T, int> frequencies = new();

        var current = head;

        // CONTAR FRECUENCIAS
        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
            {
                frequencies[current.Data]++;
            }
            else
            {
                frequencies[current.Data] = 1;
            }

            current = current.Next;
        }

        Console.WriteLine("\nGRAPH:");

        foreach (var item in frequencies)
        {
            Console.Write($"{item.Key} ");

            for (int i = 0; i < item.Value; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}