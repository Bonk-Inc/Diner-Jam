using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField]
    private DishInfo dishValues;

    public event Action<Dish> OnDishCreated;
    
    public bool AddGatheredItem(Ingredient collectedIngredient)
    {
        List<IngredientData> requiredItems = dishValues.RequiredItems;
        IngredientData ingredientInList = requiredItems.Find(i => i.Name == collectedIngredient.Name);
        
        if (null == ingredientInList)
            return false;
        
        requiredItems.Remove(ingredientInList);
        if (requiredItems.Count == 0)
            CreateDish();

        return true;
    }

    private void CreateDish()
    {
        if(OnDishCreated != null)
            OnDishCreated.Invoke(this);

        print(dishValues.DishName);   
    }
}