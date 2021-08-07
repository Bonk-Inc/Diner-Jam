using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "Recipe")]
public class ItemInfo : ScriptableObject
{
    [SerializeField]
    private string itemName;
    
    [SerializeField]
    private Sprite icon;

    public string ItemName => itemName;
    
    public Sprite Icon => icon;
}
