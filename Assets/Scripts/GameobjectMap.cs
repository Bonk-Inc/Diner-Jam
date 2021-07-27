using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectMap : MonoBehaviour
{

    [SerializeField]
    private Grid wordGrid;
    private GridMap<GameObject> gameobjectMap = new GridMap<GameObject>();

    public Grid WorldGrid => wordGrid;

    public GameObject GetCell(Vector2Int position)
    {
        return gameobjectMap.GetNode(position);
    }

    public void Add(GameObject gameObj, Vector2Int position)
    {
        gameobjectMap.SetNode(gameObj, position);
    }

    public void Remove(Vector2Int position)
    {
        gameobjectMap.RemoveNode(position);
    }
}
