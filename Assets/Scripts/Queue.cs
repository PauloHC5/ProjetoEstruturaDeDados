using UnityEngine;

public class Queue
{
    private int[] _data;
    private int _maxSize;
    private int _count;
    private int _rear;
    private int _front;

    public Queue(int maxSize)
    {
        _data = new int[maxSize];
        _maxSize = maxSize;
        _count = 0;
        _rear = 0;
        _front = 0;        
    }

    public bool IsEmpty() => _front == _rear;

    public bool IsFull() => _count == _maxSize;

    public int Count() => _count;

    public void Enqueue(int value)
    {
        if (IsFull())
        {
            Debug.LogError("Queue is full");
            return;
        }
        _data[_rear++] = value;        
        ++_count;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            Debug.LogError("Queue is empty");
            return -1;
        }
        
        --_count;
        return _data[_front];
    }
}
