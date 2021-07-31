using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishInformationIngredientsUI : MonoBehaviour
{

    [SerializeField]
    private Image ingredientPrefab; 

    //TODO Rework needed - No more Ingredients (Temp change to ItemInfo)
    public void SetIngredients(List<ItemInfo> ingredientsData)
    {
        RemoveIngredients();
        AddIngredients(ingredientsData);
    }

    private void RemoveIngredients()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void AddIngredients(List<ItemInfo> IngredientsData)
    {
        foreach (ItemInfo ingredient in IngredientsData)
        {
            AddIngredient(ingredient);
        }
    }

    private void AddIngredient(ItemInfo data)
    {
        Image ingredientUI = CreateNewIngredientUI();
        ingredientUI.sprite = data.Icon;
    }

    private Image CreateNewIngredientUI()
    {
        Image ingredientUI = Instantiate(ingredientPrefab);
        ingredientUI.transform.SetParent(this.transform);
        return ingredientUI;
    }

}
