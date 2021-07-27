using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{

    private GameobjectMap map;
    private Vector2Int position;

    private void Awake()
    {
        GameObject parentGameobj = transform.parent.gameObject;

        map = parentGameobj.GetComponent<GameobjectMap>();
        RefreshMapPosition(false);
    }

    private void RefreshMapPosition(bool remove = true)
    {
        var prevPosition = position;
        position = (Vector2Int)map.WorldGrid.WorldToCell(transform.position);

        map.Add(gameObject, position);
        if (remove)
        {
            map.Remove(position);
        }

    }


}
