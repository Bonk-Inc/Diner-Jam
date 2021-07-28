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
    public bool active, waitForMeasure, inputRequired;

    public List<RhythmComboPiece> order;

    public RhythmComboPiece toDeactivate;

    private int currentPieceNumber = 0;
    private RhythmComboPiece currentPiece;

    public void ComboUsed()
    {
        active = false;
    }

    public void CheckCombo()
    {
        if (active)
        {
            currentPiece = toDeactivate;
        }
        else
        {
            //if (waitForMeasure)
            //    return;
            currentPiece = order[currentPieceNumber];
        }


        if(currentPiece.bpmPosition.Length == 0 && currentPiece.measurePosition.Length == 0)
        {
            throw new Exception("Combo " + name + " has no bpmPositions nor measurePositions in piece " + currentPieceNumber +
                ", Should always have atleast one!");
        }

        BPMPositionCheck();
    }

    private void BPMPositionCheck()
    {
        if (currentPiece.bpmPosition.Length > 0)
        {
            int currentPosition = Mathf.FloorToInt(Conductor.RhythmConductor.SongPosition);
            foreach (int position in currentPiece.bpmPosition)
            {
                if (currentPosition == position)
                    MeasureCheck();
            }
        }
        else
        {
            MeasureCheck();
        }
    }

    private void MeasureCheck()
    {
        if (currentPiece.measurePosition.Length > 0)
        {
            int currentPosition = Conductor.RhythmConductor.MeasurePosition;
            foreach (int position in currentPiece.measurePosition)
            {
                if (currentPosition == position)
                {
                    if (currentPiece.keycodes.Length > 0)
                    {
                        inputRequired = true;
                        InputCheck();
                    }
                    else
                        ContinueCombo();
                }
            }
        }
        else
        {
            if (currentPiece.keycodes.Length > 0)
            {
                inputRequired = true;
                InputCheck();
            }
            else
                ContinueCombo();
        }
    }

    public void InputCheck()
    {
        // TODO: Actual Input checks
        inputRequired = false;
        ContinueCombo();
    }

    private void ContinueCombo()
    {
        if (currentPieceNumber + 1 >= order.Count)
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
            currentPieceNumber += 1;
        }
    }

    public void ResetCombo()
    {
        currentPieceNumber = 0;
    }
    
}
