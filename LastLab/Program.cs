using System;
using System.Collections.Generic;

public interface IQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
    bool IsEmpty();
    int Count { get; }
}

public class Car
{
    public int? Id { get; set; }
    public string? Type { get; set; }
    public string? Passengers { get; set; }
    public bool? IsDining { get; set; }
    public int? Consumption { get; set; }
}

public class ArrayQueue<T> : IQueue<T>
{
    private List<T> items = new List<T>();

    public void Enqueue(T item) => items.Add(item);

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        T item = items[0];
        items.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        return items[0];
    }

    public bool IsEmpty() => items.Count == 0;
    public int Count => items.Count;
}

public class LinkedQueue<T> : IQueue<T>
{
    private LinkedList<T> items = new LinkedList<T>();

    public void Enqueue(T item) => items.AddLast(item);

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        var firstNode = items.First;
        if (firstNode == null)
            throw new InvalidOperationException("Queue is empty");

        T item = firstNode.Value;
        items.RemoveFirst();
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        var firstNode = items.First;
        if (firstNode == null)
            throw new InvalidOperationException("Queue is empty");

        return firstNode.Value;
    }

    public bool IsEmpty() => items.Count == 0;
    public int Count => items.Count;
}

public class CircularQueue<T> : IQueue<T>
{
    private T[] items;
    private int front = 0;
    private int rear = -1;
    private int count = 0;

    public CircularQueue(int capacity = 10)
    {
        items = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if (Count == items.Length)
            Array.Resize(ref items, items.Length * 2);

        rear = (rear + 1) % items.Length;
        items[rear] = item;
        count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        T item = items[front];
        front = (front + 1) % items.Length;
        count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        return items[front];
    }

    public bool IsEmpty() => Count == 0;
    public int Count => count;
}