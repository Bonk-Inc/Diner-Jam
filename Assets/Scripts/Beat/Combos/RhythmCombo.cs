using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RhythmCombo
{
    public string name;
    [TextArea(3, 10)]
    public string description;

    public event Action ComboFinished;
    public bool active, inputRequired;
    public int currentPieceNumber = 0;

    public List<RhythmComboPiece> order;

    private RhythmComboPiece currentPiece;

    public void ComboUsed()
    {
        active = false;
    }

    public void CheckCombo()
    {
        if(inputRequired){
            if(currentPiece.isBadInput)
                ContinueCombo();
            else
                ResetCombo();
        }

        active = false;
        currentPiece = order[currentPieceNumber];

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
        foreach (KeyCode key in currentPiece.keycodes)
        {
            if (Input.GetKeyDown(key))
            {
                if(currentPiece.isBadInput){
                    ResetCombo();
                }
                else{
                    ContinueCombo();
                }
                return;
            }   
        }
    }

    private void ContinueCombo()
    {
        inputRequired = false;
        if (currentPieceNumber + 1 >= order.Count)
        {
            if (ComboFinished != null)
                ComboFinished.Invoke();

            active = true;
            ResetCombo();
        }
        else
        {
            currentPieceNumber += 1;
        }
    }

    public void ResetCombo()
    {
        inputRequired = false;
        currentPieceNumber = 0;
        currentPiece = null;
    }
    
}
