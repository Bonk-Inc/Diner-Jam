using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishUIManager : MonoBehaviour
{

    [SerializeField]
    private DishUI dishUIprefab;

    private List<DishUI> currentObjectiveUIElements = new List<DishUI>();

    public void AddDishUI(DishInfo dish)
    {
        DishUI dishUI = Instantiate(dishUIprefab);
        dishUI.transform.SetParent(this.transform);
        dishUI.SetDishInfo(dish);

        currentObjectiveUIElements.Add(dishUI);
    }

    public void RemoveDish(DishInfo dishToRemove)
    {
        int dishIndex = currentObjectiveUIElements.FindIndex((dish) => dish.DishData.DishName == dishToRemove.DishName);
        if(dishIndex < 0)
        {
            return;
        }

        DishUI uiToRemove = currentObjectiveUIElements[dishIndex];
        currentObjectiveUIElements.RemoveAt(dishIndex);
        Destroy(uiToRemove);
    }
    
}
