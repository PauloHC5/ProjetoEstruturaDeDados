using NUnit.Framework.Constraints;
using UnityEngine;

public class Search : MonoBehaviour
{
    public int[] data;

    private int _count = 0;

    private void Start()
    {
        int size = 10;
        data = new int[size];

        for (int i = 0; i < size; i++)
        {
            data[i] = Random.Range(1, 10000);
        }

        data = new int[30] { 46, 27, 67, 80, 88, 55, 33, 84, 30, 26, 21, 88, 8, 34, 34, 14, 24, 62, 73, 11, 51, 44, 70, 100, 75, 87, 50, 45, 28, 71 };

        SortArray();

        int result = BinarySearch(46);
        Debug.Log("O indice encontrado foi: " + result + " em " + _count + " iterações");

    }

    public int BinarySearch(int value)
    {
        int begin = 0;
        int end = data.Length - 1;



        while(begin <= end)
        {
            _count++;

            int middle = (begin + end) / 2;
            
            if(data[middle] == value)
                return middle;

            if (data[middle] < value)
            {
                begin = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
            
        }

        return -1;
    }

    public void SortArray()
    {
        for (int i = data.Length - 1; i > 0; i--)
        {
            bool notSwapped = true;

            for (int j = 0; j < i; j++)
            {
                if (data[j] > data[j + 1])
                {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                    notSwapped = false;
                }
            }

            if (notSwapped)
                break;
        }
    }
}
