using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dish : MonoBehaviour
{
    [SerializeField]
    protected string name;

    [SerializeField]
    protected List<string> requiredItems = new List<string>();

    public bool AddGatheredItem(Ingredient collectedIngredient)
    {
        string ingredientInList = requiredItems.Find(i => i == collectedIngredient.Name);
        
        if (null == ingredientInList)
            return false;
        
        requiredItems.Remove(ingredientInList);
        if (requiredItems.Count == 0)
            CreateDish();

        return true;
    }

    protected abstract void CreateDish();
}