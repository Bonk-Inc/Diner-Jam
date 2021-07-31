using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : InteractableTile
{
    [SerializeField]
    private string comboName;

    [SerializeField]
    private Ingredient boxIngredient;
    private ConductorEventKeeper comboKeeper;

    private RhythmCombo pickUpCombo;

    public Ingredient BoxIngredient => boxIngredient;

    public override void Interact(PlayerInteractor player)
    {
        if(pickUpCombo.active){
            if(player.HasItem())
                return;
                
            Ingredient ingredient = Instantiate(boxIngredient);
            player.PutInInventory(ingredient.gameObject);
        }
    }

    private void Start(){
        comboKeeper = Conductor.RhythmConductor.GetComponent<ConductorEventKeeper>();
        pickUpCombo = comboKeeper.FindCombo(comboName);
    }
}
