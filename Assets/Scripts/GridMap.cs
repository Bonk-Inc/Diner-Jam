using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap<T> : IEnumerable
{
    private readonly Dictionary<Vector2Int, T> grid;

    public Dictionary<Vector2Int, T> GridObject => grid;

    public T this[int x, int y]
    {
        get => GetNode(x, y);
        set => SetNode(value, x, y);
    }

    public T this[Vector2Int position]
    {
        get => GetNode(position); 
        set => SetNode(value, position); 
    }

    public GridMap()
    {
        grid = new Dictionary<Vector2Int, T>();
        ResetGrid();
    }

    public T GetNode(Vector2Int position)
    {
        if (!grid.ContainsKey(position))
            return default;

        return grid[position];
    }
    public T GetNode(int x, int y) => GetNode(new Vector2Int(x, y));

    public void SetNode(T newNode, Vector2Int position) {
        grid[position] = newNode;
    }
    public void SetNode(T newNode, int x, int y) => SetNode(newNode, new Vector2Int(x, y));


    public void RemoveNode(Vector2Int position)
    {
        grid.Remove(position);
    }

    public void ResetGrid()
    {
        grid.Clear();
    }

    public Vector2Int[] GetNeighbourPositions(Vector2Int nodePosition, bool crossWise = true)
    {
        List<Vector2Int> positions = new List<Vector2Int>();
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {

                if ((!crossWise && (y == 1 || y == -1) && (x == 1 || x == -1)) ||
                    x == 0 && y == 0)
                    continue;

                var position = new Vector2Int(x, y) + nodePosition;

                positions.Add(position);
            }
        }
        return positions.ToArray();

    }

    public T[] GetNeighbours(Vector2Int nodePosition, bool crossWise = true, bool allowNull = false)
    {
        Vector2Int[] positions = GetNeighbourPositions(nodePosition, crossWise);
        List<T> neighbours = new List<T>();
        for (int i = 0; i < positions.Length; i++)
        {
            var neighbour = GetNode(positions[i]);
            if (!allowNull && neighbour == null)
                continue;

            neighbours.Add(GetNode(positions[i]));
        }
        return neighbours.ToArray();

    }

    public T[] GetRelatives(Vector2Int nodePosition, Vector2Int[] reletivesPositions)
    {
        var reletives = new List<T>();

        for (int i = 0; i < reletivesPositions.Length; i++)
        {
            reletives.Add(GetRelative(nodePosition, reletivesPositions[i]));
        }

        return reletives.ToArray();
    }

    public T GetRelative(Vector2Int nodePosition, Vector2Int relativePosition){
        return GetNode(nodePosition + relativePosition);
    }

    public IEnumerator GetEnumerator() => grid.GetEnumerator();
}