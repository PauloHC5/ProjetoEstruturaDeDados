using System.Numerics;
using UnityEngine;

public class Queue<T>
{
    private T[] _data;
    private int _rear;
    private int _front;
    private int _size;
    private int _resizeFactor;

    public Queue(int size, int factor = -1)
    {
        _data = new T[size];
        _size = size;
        _rear = 0;
        _front = 0;
        _resizeFactor = factor;
    }

    public bool IsEmpty() => _front == _rear;
    public bool IsFull() => _rear == _size;

    public int Count() => _rear - _front;

    private void ReSize()
    {
        int reSizeLenght = _resizeFactor == -1 ? (int)_size / 2 : _resizeFactor;

        _size += reSizeLenght;

        T[] newArray = new T[_size];
        for(int i = _front; i < _data.Length; i++)
        {
            newArray[i - _front] = _data[i];
        }

        _rear -= _front;
        _front = 0;
        _data = newArray;
    }



    public void Enqueue(T value)
    {        
        if(IsFull())
        {
            ReSize();
        }
        _data[_rear++] = value;
    }

    public T Dequeue()
    {
        Debug.Assert(_front != _rear);

        int index = _front++;

        if(_front == _rear)
        {
            _rear = _front = 0;
        }

        return _data[index];
    }
}
