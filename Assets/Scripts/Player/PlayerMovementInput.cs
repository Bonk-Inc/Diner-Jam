using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInput : MonoBehaviour
{

    private PlayerMovement mover;

    private RhythmCombo combo;

    public RhythmCombo Combo { set => combo = value; }

    private void Awake()
    {
        mover = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        MoveDirection direction = CheckMovementInput();

        if(direction == MoveDirection.NONE)
        {
            return;
        }

        if (combo.active)
        {
            combo.ComboUsed();
            mover.Move(direction);
        }

        //TODO else punish?

    }

    private MoveDirection CheckMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return MoveDirection.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            return MoveDirection.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            return MoveDirection.DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            return MoveDirection.UP;
        }

        return MoveDirection.NONE;
    }



}
