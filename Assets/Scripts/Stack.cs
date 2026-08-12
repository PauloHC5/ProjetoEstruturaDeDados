using System;
using UnityEngine;

[Serializable]
public class Stack<T>
{    
    private T[] _data;    
    private int _top;
    private int _size;

    public Stack(int size = 10)
    {        
        _size = size;        
        _top = 0;
        _data = new T[size];
    }

    public bool IsEmpty()
    {
        return _top == 0;
    }

    public int Count()
    {
        return _top;
    }

    public T Top()
    {
        Debug.Assert(!IsEmpty());

        return _data[_top - 1];
    }

    public void Push(T value)
    {
        Debug.Assert(_top < _size);

        _data[_top++] = value;
    }

    public T Pop()
    {
        Debug.Assert(!IsEmpty());

        T result = _data[--_top];
        _data[--_top] = default;

        return result;
    }

    public void Clear()
    {
        _top = 0;
        Array.Clear(_data, 0, _size);
    }
}
