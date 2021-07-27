using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorEventKeeper : MonoBehaviour
{
    [SerializeField]
    private List<RhythmCombo> comboOrder;

    private void Update()
    {
        foreach (RhythmCombo combo in comboOrder)
        {
            combo.CheckCombo();
        }
    }

    // Change string name into an enum?
    public RhythmCombo FindCombo(string name)
    {
        foreach (RhythmCombo combo in comboOrder)
        {
            if (combo.name.Equals(name))
                return combo;
        }
        return null;
    }
}
