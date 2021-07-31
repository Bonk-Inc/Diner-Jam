using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTile : InteractableTile
{
    public GameObject item;

    protected bool canPickUp = true;

    public override void Interact(PlayerInteractor player)
    {
        if(item == null){
            if(player.HasItem()){
                item = player.GetInventoryItem();

                item.transform.SetParent(transform);
                item.transform.localPosition = Vector3.zero;
            }
        } else {
            if(!player.HasItem() && canPickUp){
                player.PutInInventory(item);
                item = null;
            }
        }   
    }
}
