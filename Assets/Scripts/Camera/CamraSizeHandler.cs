using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CamraSizeHandler : MonoBehaviour
{

    private Camera cam;

    public Camera Camera => cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public abstract void SetSize(float size);
    public void SetSizeDirect(float size)
    {
        cam.orthographicSize = size;
    }

}
