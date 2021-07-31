using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "Recipe")]
public class DishInfo : ScriptableObject
{
    [SerializeField]
    private string dishName;
    
    [SerializeField]
    private List<IngredientData> requiredItems = new List<IngredientData>();

    [SerializeField]
    private Sprite icon;

    public string Name => dishName;
    
    public List<IngredientData> RequiredItems => requiredItems;

    public Sprite Icon => icon;
}
