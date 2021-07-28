using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RhythmCombo
{
    public string name;
    public string description;

    public event Action ComboFinished;
    public bool active, waitForMeasure;

    public List<RhythmComboPiece> order;

    public RhythmComboPiece toDeactivate;

    private int currentPiece = 0;

    public void ComboUsed()
    {
        active = false;
    }

    public void CheckCombo()
    {

        RhythmComboPiece piece;
        if (active)
        {
            piece = toDeactivate;
        }
        else
        {
            if (waitForMeasure)
                return;
            piece = order[currentPiece];
        }


        if(piece.bpmPosition.Length == 0 && piece.measurePosition.Length == 0)
        {
            throw new Exception("Combo " + name + " has no bpmPositions nor measurePositions in piece " + currentPiece +
                ", Should always have atleast one!");
        }

        BPMPositionCheck(piece);
    }

    private void BPMPositionCheck(RhythmComboPiece piece)
    {
        if (piece.bpmPosition.Length > 0)
        {
            int currentPosition = Mathf.FloorToInt(Conductor.RhythmConductor.SongPosition);
            foreach (int position in piece.bpmPosition)
            {
                if (currentPosition == position)
                    MeasureCheck(piece);
            }
        }
        else
        {
            MeasureCheck(piece);
        }
    }

    private void MeasureCheck(RhythmComboPiece piece)
    {
        if (piece.measurePosition.Length > 0)
        {
            int currentPosition = Conductor.RhythmConductor.MeasurePosition;
            foreach (int position in piece.measurePosition)
            {
                if (currentPosition == position)
                {

                    InputCheck(piece);
                }
            }
        }
        else
        {
            InputCheck(piece);
        }
    }

    private void InputCheck(RhythmComboPiece piece)
    {
        // TODO: Actual Input checks

        if(currentPiece + 1 >= order.Count)
        {
            Debug.Log(name + " has been complete!");
            if (ComboFinished != null)
                ComboFinished.Invoke();

            active = !active;
            waitForMeasure = !waitForMeasure;
            ResetCombo();
        }
        else
        {
            currentPiece += 1;
        }
    }

    public void ResetCombo()
    {
        currentPiece = 0;
    }
    
}
