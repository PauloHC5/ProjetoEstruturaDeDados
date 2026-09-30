using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "PUC/DataItem")]
public class DataItem : ScriptableObject
{
    public string itemName;
    public float price;
    [TextArea]
    public string description;
}
