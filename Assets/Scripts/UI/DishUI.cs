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

    private ItemInfo data;

    public ItemInfo DishData => data;

    public void SetDishInfo(ItemInfo data)
    {
        this.data = data;
        dishName.SetText(data.ItemName);
        dishIcon.sprite = data.Icon;
        // TODO FIX, data doesnt have requiredItems anymore.
        // ingredientsUI.SetIngredients(data.RequiredItems);
    }



}
