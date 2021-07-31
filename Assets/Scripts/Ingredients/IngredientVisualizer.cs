using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ingredient))]
public class IngredientVisualizer : MonoBehaviour
{
    [SerializeField]
    private Ingredient ingredient;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Reset()
    {
        ingredient = GetComponent<Ingredient>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        ingredient.OnDataSet += (sender, data) => VisualizeIngredient(data);
    }

    private void VisualizeIngredient(IngredientData data)
    {
        spriteRenderer.sprite = data.Icon;
    }

}
