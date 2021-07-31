using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishInformationIngredientsUI : MonoBehaviour
{

    [SerializeField]
    private Image ingredientPrefab; 

    public void SetIngredients(List<IngredientData> ingredientsData)
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

    private void AddIngredients(List<IngredientData> IngredientsData)
    {
        foreach (IngredientData ingredient in IngredientsData)
        {
            AddIngredient(ingredient);
        }
    }

    private void AddIngredient(IngredientData data)
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
