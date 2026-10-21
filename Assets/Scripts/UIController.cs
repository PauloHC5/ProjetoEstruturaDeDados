using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ToggleState
{
    Name,
    Asc,
    Desc
}

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject uiItemPrefab;
    [SerializeField] private Transform content;

    private DataItem[] inventory;
    private ToggleState toggleState = ToggleState.Name;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = Resources.LoadAll<DataItem>("Items");
        BubbleSort();

        for (int i = 0; i < inventory.Length; i++)
        {
            CreateUIItem(inventory[i]);
        }
    }

    private void CreateUIItem(DataItem item)
    {
        GameObject uiItem = Instantiate(uiItemPrefab, content);
        uiItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemName;
        uiItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.price.ToString("0.00");
        uiItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.description;
    }

    private void ResetUI()
    {
        DestroyUI();

        BubbleSort();

        for (int i = 0; i < inventory.Length; i++)
        {
            CreateUIItem(inventory[i]);
        }
    }

    private void DestroyUI()
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }

    public void Search(string values)
    {
        SensitiveSearch(values);
    }

    private void SensitiveSearch(string value)
    {
        DestroyUI();
        if(string.IsNullOrEmpty(value))
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                CreateUIItem(inventory[i]);
            }
            return;
        }

        List<DataItem> values = SequentialSearchByName(value);

        for (int i = 0; i < values.Count; i++)
        {
            CreateUIItem(values[i]);
        }
    }

    private List<DataItem> SequentialSearchByName(string value)
    {
        List<DataItem> result = new List<DataItem>();

        string upperTarget = value.ToUpper();
        for (int i = 0; i < inventory.Length; i++)
        {
            var upperSource = inventory[i].itemName.ToUpper();

            if(upperTarget[0].CompareTo(upperSource[0]) > 0)
            {
                continue;
            }

            if (upperTarget[0].CompareTo(upperSource[0]) < 0)
            {
                break;
            }

            if (upperSource.Length >= upperTarget.Length && (upperSource.Substring(0, upperTarget.Length) == upperTarget))
            {
                result.Insert(inventory[i]);
            }
        }

        return result;
    }

    private void BubbleSort()
    {
        for (int i = inventory.Length - 1; i > 0; i--)
        {
            bool notSwapped = true;

            for (int j = 0; j < i; j++)
            {
                bool result = false;
                switch (toggleState)
                {
                    case ToggleState.Name:
                        result = inventory[j].itemName.CompareTo(inventory[j + 1].itemName) > 0;
                        break;
                    case ToggleState.Asc:
                        result = inventory[j].price > inventory[j + 1].price;
                        break;
                    case ToggleState.Desc:
                        result = inventory[j].price < inventory[j + 1].price;
                        break;
                    default:
                        result = false;
                        break;
                }

                if (result)
                {
                    notSwapped = false;
                    DataItem temp = inventory[j];
                    inventory[j] = inventory[j + 1];
                    inventory[j + 1] = temp;
                }
            }

            if (notSwapped) break;
        }        
    }

    public void SetStateName(bool value)
    {
        if (value)
        {
            toggleState = ToggleState.Name;
            ResetUI();
        }      
    }

    public void SetStateAsc(bool value)
    {

        if (value)
        {
            toggleState = ToggleState.Asc;
            ResetUI();
        }
    }

    public void SetStateDesc(bool value)
    {
        if (value)
        {
            toggleState = ToggleState.Desc;
            ResetUI();
        }
    }
}
