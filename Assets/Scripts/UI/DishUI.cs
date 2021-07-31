using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishUI : MonoBehaviour
{
    [SerializeField]
    private DishInfo dish;

    [SerializeField]
    private Image dishIcon;

    public void SetDish(DishInfo dish)
    {
        this.dish = dish;
    }

}
