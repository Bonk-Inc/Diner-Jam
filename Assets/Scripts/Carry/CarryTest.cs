using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryTest : MonoBehaviour
{
    [SerializeField] private GameobjectMap gameobjectMap;

    void Start()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.transform.position = new Vector3(0.5f, 0.5f, -0.5f);
        gameobjectMap.Add(obj, Vector2Int.zero);
    }
}
