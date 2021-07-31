using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanTile : InteractableTile
{
    public override void Interact(PlayerInteractor player)
    {
        GameObject item = player.GetInventoryItem();
        Destroy(item);
    }
}
