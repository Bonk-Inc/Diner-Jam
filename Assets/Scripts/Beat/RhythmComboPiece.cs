using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RhythmComboPiece
{
    public int[] bpmPosition;
    public int[] measurePosition;

    public bool isBadInput;
    public KeyCode[] keycodes;
}
