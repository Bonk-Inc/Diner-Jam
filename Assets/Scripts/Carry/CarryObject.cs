using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    private GameobjectMap gameobjectMap;
    private GridPosition gridPosition;
    private Transform interaction;
    private Vector3 offset = new Vector3(0.5f, 0.5f, -0.5f);
    private GameObject carrying;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        gridPosition = GetComponent<GridPosition>();
    }

    public GameobjectMap GameobjectMap
    {
        get => gameobjectMap;
        set => SetGameobjectMap(value);
    }

    public Transform Interaction
    {
        get => interaction;
        set => SetInteraction(value);
    }

    private void SetGameobjectMap(GameobjectMap newGameobjectMap)
    {
        gameobjectMap = newGameobjectMap;
    }

    private void SetGridPosition(GridPosition newGridPosition)
    {
        gridPosition = newGridPosition;
    }

    private void SetInteraction(Transform newInteraction)
    {
        interaction = newInteraction;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (carrying != null)
            {
                Drop();
            }
            else
            {
                PickUp();
            }
        }
    }

    public void PickUp()
    {
        //get position to pick up from //player position or player position + player.forward
        Vector2Int position = gridPosition.Position + playerMovement.LookingAt;

        //check if object on position
        GameObject objectOnPosition = gameobjectMap.GetCell(position);
        if (objectOnPosition != null /* && objectOnPosition.GetComponent<Carryable>() != null */)
        {
            //remember what you are carrying
            carrying = gameobjectMap.GetCell(position);
            //remove from grid
            gameobjectMap.Remove(position);
            //set player as parent
            carrying.transform.SetParent(transform);
            //move to player animation?
            ///////////////////////////////////////carrying.transform.position = new Vector3(gridPosition.Position.x, gridPosition.Position.y, -0.5f);
        }
    }

    public void Drop()
    {
        //get position to drop //player position or player position + player.forward
        Vector2Int position = gridPosition.Position + playerMovement.LookingAt;

        //check if object on position
        GameObject objectOnPosition = gameobjectMap.GetCell(position);
        if (objectOnPosition == null)
        {
            //remove player as parent
            carrying.transform.SetParent(interaction);
            //add to grid
            gameobjectMap.Add(carrying, position);
            //move to location animation?
            carrying.transform.position = new Vector3(position.x, position.y, 0) + offset;
            //forget what you were carrying
            carrying = null;

        }

    }
}
