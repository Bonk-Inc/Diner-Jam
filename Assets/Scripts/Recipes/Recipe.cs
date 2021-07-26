using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : ScriptableObject
{
    [SerializeField]
    protected string name;

    [SerializeField]
    protected List<Ingredient> requiredItems;

    protected List<Ingredient> gatheredItems;

    public bool CanBePrepared => gatheredItems.Equals(requiredItems);
    
    public void AddGatheredItem(Ingredient ingredient)
    {
        gatheredItems.Add(ingredient);
    }
}