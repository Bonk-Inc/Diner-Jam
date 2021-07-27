using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dish : MonoBehaviour
{
    [SerializeField]
    protected string name;

    [SerializeField]
    protected List<Ingredient> requiredItems = new List<Ingredient>();

    public bool AddGatheredItem(Ingredient collectedIngredient)
    {
        Ingredient ingredientInList = requiredItems.Find(i => i.GetType() == collectedIngredient.GetType());
        
        if (null == ingredientInList)
            return false;
        
        requiredItems.Remove(ingredientInList);
        if (requiredItems.Count == 0)
            CreateDish();

        return true;
    }

    protected abstract void CreateDish();
}