using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class IngredientData : ScriptableObject
{
    [SerializeField]
    private string dishName;

    [SerializeField]
    private Sprite icon;

    public string Name => dishName;

    public Sprite Icon => icon;

}
