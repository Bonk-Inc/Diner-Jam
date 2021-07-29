using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorEventKeeper : MonoBehaviour
{
    [SerializeField]
    private List<RhythmCombo> comboOrder;

    private void Start()
    {
        Conductor.RhythmConductor.OnMeasureChange += CheckNewMeasure;
    }

    private void Update()
    {
        foreach (RhythmCombo combo in comboOrder)
        {
            if(combo.inputRequired)
                combo.InputCheck();
        }
    }

    public RhythmCombo FindCombo(string name)
    {
        foreach (RhythmCombo combo in comboOrder)
        {
            if (combo.name.Equals(name))
                return combo;
        }
        return null;
    }

    private void CheckNewMeasure()
    {
        foreach (RhythmCombo combo in comboOrder)
        {
            combo.CheckCombo();
        }
    }
}
