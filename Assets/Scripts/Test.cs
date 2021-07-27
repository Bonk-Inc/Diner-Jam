using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    [SerializeField]
    Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        var tile = map.GetTile(Vector3Int.zero);
        print(tile);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
