using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition : MonoBehaviour
{
    
    private Grid grid;
    private Vector2Int position;
    private PositionChanger positionChanger;

    public Vector2Int Position { 
        get => position; 
        set => SetPosition(value); 
    }

    public Grid Grid
    {
        get => grid;
        set => SetGrid(value);
    }

    private void Awake()
    {
        positionChanger = GetComponent<PositionChanger>();
    }

    private void SetGrid(Grid newGrid)
    {
        grid = newGrid;
    }

    public void SetPosition(Vector2Int newPosition, bool direct = false)
    {
        position = newPosition;

        if (!grid)
        {
            Debug.LogWarning("Tried to set the gridposition without a grid");
            return;
        }

        Vector3 worldPosition = grid.GetCellCenterWorld((Vector3Int)position);

        if (direct)
        {
            positionChanger.SetPositionDirect(worldPosition);
        } else
        {
            positionChanger.MoveTo(worldPosition);
        }

        

    }




}
