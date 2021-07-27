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

    [SerializeField] 
    private Apple preApple;

    [SerializeField]
    private Sugar preSugar;

    private void Start()
    {
        Apple apple = Instantiate(preApple, transform);
        Sugar sugar = Instantiate(preSugar, transform);
     
        AddGatheredItem(apple);
        AddGatheredItem(sugar);
    }

    public void AddGatheredItem(Ingredient collectedIngredient)
    {
        Ingredient ingredientInList = requiredItems.Find(i => i.GetType() == collectedIngredient.GetType());
        requiredItems.Remove(ingredientInList);

        if (requiredItems.Count > 0)
            CreateDish();
    }

    protected abstract void CreateDish();
}