using Shared;
using System.Collections.Generic;
using System.Linq;

namespace DoubleList;

public class DoubleLinkedList<T>
    where T : IComparable<T>
{
    private Node<T>? head;
    private Node<T>? tail;

    public void InsertOrdered(T data)
    {
        var newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
            return;
        }

        var current = head;

        if (data.CompareTo(head.Data) < 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;

            return;
        }

        while (current.Next != null &&
               current.Next.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            current.Next = newNode;
            newNode.Previous = current;
            tail = newNode;

            return;
        }

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

                else if (current == tail)
                {
                    tail = current.Previous;

                    if (tail != null)
                    {
                        tail.Next = null;
                    }
                }

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

                else if (current == tail)
                {
                    tail = tail.Previous;

                    if (tail != null)
                    {
                        tail.Next = null;
                    }
                }

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


        int maxFrequency = frequencies.Values.Max();

        var modes = frequencies
            .Where(x => x.Value == maxFrequency)
            .Select(x => x.Key);

        Console.WriteLine("The mode(s) are:");

        Console.WriteLine(string.Join(", ", modes));
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

        foreach (var item in frequencies.OrderBy(x => x.Key))
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