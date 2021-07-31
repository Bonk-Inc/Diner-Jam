using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTile : InteractableTile {

    public GameObject itemOnStove;

    public override void Interact(PlayerInteractor player) {
        if (itemOnStove == null) {
            if (player.HasItem()) {
                itemOnStove = player.GetInventoryItem();

                itemOnStove.transform.SetParent(transform);
                itemOnStove.transform.localPosition = Vector3.zero;
            }
        } else {
            if (!player.HasItem()) {
                player.PutInInventory(itemOnStove);
                itemOnStove = null;
            }
        }
    }
}