using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishUI : MonoBehaviour
{
    [SerializeField]
    private Image dishIcon;

    [SerializeField]
    private TMPro.TextMeshProUGUI dishName;

    [SerializeField]
    private DishInformationIngredientsUI ingredientsUI;

    private DishInfo data;

    public DishInfo DishData => data;

    public void SetDishInfo(DishInfo data)
    {
        this.data = data;
        dishName.SetText(data.DishName);
        dishIcon.sprite = data.Icon;
        ingredientsUI.SetIngredients(data.RequiredItems);
    }



}
