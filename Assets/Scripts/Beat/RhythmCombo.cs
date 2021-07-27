using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RhythmCombo
{
    public string name;

    public Action ComboFinished;
    public bool comboActive;

    public List<RhythmComboPiece> order;

    private RhythmComboPiece currentPiece;

    public void CheckCombo()
    {

    }
    
}
