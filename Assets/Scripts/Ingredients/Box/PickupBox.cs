using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour
{
    [SerializeField]
    private string comboName;

    [SerializeField]
    private Ingredient boxIngredient;
    private ConductorEventKeeper comboKeeper;

    private RhythmCombo pickUpCombo;

    public Ingredient BoxIngredient => boxIngredient;

    private void Start(){
        comboKeeper = Conductor.RhythmConductor.GetComponent<ConductorEventKeeper>();
        pickUpCombo = comboKeeper.FindCombo(comboName);
    }

    //TODO Spawn ingredient in and put it in players hand.
    private void Update(){  
        if(pickUpCombo.active && Input.GetKeyDown("space")){

        }
    }




}
