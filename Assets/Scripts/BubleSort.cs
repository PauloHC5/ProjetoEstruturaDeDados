using UnityEngine;

public class BubleSort : MonoBehaviour
{

    public int[] arrayToSort = new int[10];

    void Start()
    {
        Debug.Log("Original array: " + string.Join(", ", arrayToSort));
        SortArray();
        Debug.Log("Sorted array: " + string.Join(", ", arrayToSort));
    }

    public void SortArray()
    {       
        for (int i = arrayToSort.Length - 1; i > 0; i--)
        {
            bool notSwapped = true;

            for (int j = 0; j < i; j++)
            {
                if (arrayToSort[j] > arrayToSort[j + 1])
                {
                    int temp = arrayToSort[j];
                    arrayToSort[j] = arrayToSort[j + 1];
                    arrayToSort[j + 1] = temp;
                    notSwapped = false;
                }                
            }

            if (notSwapped)
                break;
        }
    }
    
}
