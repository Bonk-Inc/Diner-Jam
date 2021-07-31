using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBoxVisual : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer renderer;

    private PickupBox pickupBox;
    private void Start() {
        pickupBox = GetComponent<PickupBox>();
        renderer.sprite = pickupBox.BoxIngredient.Data.Icon;
    }
}
