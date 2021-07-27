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
    
    public void AddGatheredItem(Ingredient collectedIngredient)
    {
        Ingredient ingredientInList = requiredItems.Find(i => i.GetType() == collectedIngredient.GetType());
        requiredItems.Remove(ingredientInList);

        if (requiredItems.Count > 0)
            CreateDish();
    }

    protected abstract void CreateDish();
}