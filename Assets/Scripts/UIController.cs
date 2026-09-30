using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject uiItemPrefab;
    [SerializeField] private Transform content;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject uiItem = Instantiate(uiItemPrefab, content);
            uiItem.GetComponentInChildren<TextMeshProUGUI>().text = $"Item {i + 1}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
