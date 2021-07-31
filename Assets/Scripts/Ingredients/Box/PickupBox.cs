using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : InteractableTile
{
    [SerializeField]
    private string comboName;

    [SerializeField]
    private Item boxIngredient;
    private ConductorEventKeeper comboKeeper;

    private RhythmCombo pickUpCombo;

    public Item BoxIngredient => boxIngredient;

    public override void Interact(PlayerInteractor player)
    {
        if(pickUpCombo.active){
            if(player.HasItem())
                return;
                
            Item ingredient = Instantiate(boxIngredient);
            player.PutInInventory(ingredient.gameObject);
        }
    }

    private void Start(){
        comboKeeper = Conductor.RhythmConductor.GetComponent<ConductorEventKeeper>();
        pickUpCombo = comboKeeper.FindCombo(comboName);
    }
}
