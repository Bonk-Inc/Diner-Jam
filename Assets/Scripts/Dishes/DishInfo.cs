using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "Recipe")]
public class DishInfo : ScriptableObject
{
    [SerializeField]
    private string name;
    
    [SerializeField]
    private List<string> requiredItems = new List<string>();
    
    

    public string Name => name;
    
    public List<string> RequiredItems => requiredItems;
}
