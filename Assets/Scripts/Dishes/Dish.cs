using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField]
    private DishInfo dishValues;
    
    public bool AddGatheredItem(Ingredient collectedIngredient)
    {
        List<string> requiredItems = dishValues.RequiredItems;
        string ingredientInList = requiredItems.Find(i => i == collectedIngredient.Name);
        
        if (null == ingredientInList)
            return false;
        
        requiredItems.Remove(ingredientInList);
        if (requiredItems.Count == 0)
            CreateDish();

        return true;
    }

    private void CreateDish()
    {
        print(dishValues.Name);   
    }
}