using System;
using UnityEngine;

[Serializable]
public class Stack
{    
    private int[] _data;
    private int _maxSize;
    private int _top;

    public Stack(int maxSize)
    {
        _maxSize = maxSize;
        _data = new int[maxSize];
        _top = 0;
    }

    public bool IsEmpty()
    {
        return _top == 0;
    }

    public int Size()
    {
        return _maxSize;
    }

    public int Top()
    {
        if( IsEmpty())
        {
            Debug.LogError("Pilha Vazia!!");
            return -1;
        }

        return _data[_top - 1];
    }

    public void Push(int value)
    {
        if (_top >= _maxSize)
        {
            Debug.LogError("Não inserido, pilha cheia!");
            return;
        }

        _data[_top++] = value;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Debug.LogError("Pilha Vazia!!");
            return -1;
        }

        return _data[--_top];
    }
}
