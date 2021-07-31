using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour
{

    [SerializeField]
    private ConductorEventKeeper comboKeeper;
    [SerializeField]
    private string comboName;

    [SerializeField]
    private Ingredient ingredient;

    private RhythmCombo pickUpCombo;

    private void Start(){
        pickUpCombo = comboKeeper.FindCombo(comboName);
    }

    private void Update(){
        if(pickUpCombo.active && Input.GetKeyDown("space")){

        }
    }


}
