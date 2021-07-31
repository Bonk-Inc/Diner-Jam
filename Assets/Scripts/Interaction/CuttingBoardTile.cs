using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardTile : PickupTile
{
    [SerializeField]
    private string combo;

    private ConductorEventKeeper keeper;
    private RhythmCombo cuttingCombo;

    private void Start(){
        keeper = Conductor.RhythmConductor.GetComponent<ConductorEventKeeper>();
        cuttingCombo = keeper.FindCombo(combo);
    }

    public override void Interact(PlayerInteractor player)
    {
        base.Interact(player);
        canPickUp = false;
        cuttingCombo.ComboFinished = Cut;
    }

    private void Cut(){
        canPickUp = true;
        Ingredient ingredient = item.GetComponent<Ingredient>();
        if(ingredient == null)
            return;
        
        
        //ingredient.Data.Cuttable;
    }
}
