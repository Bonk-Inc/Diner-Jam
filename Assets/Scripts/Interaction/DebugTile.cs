using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTile : InteractableTile
{

public GameObject item;

    public override void Interact(PlayerInteractor player)
    {
        print("ayy");
    }
}
