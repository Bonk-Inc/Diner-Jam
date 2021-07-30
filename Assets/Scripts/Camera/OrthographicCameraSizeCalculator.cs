using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OrthographicCameraSizeCalculator : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float margin;

    [SerializeField]
    private float minSize;

    [SerializeField]
    private Bounds bounds;


    public void SetBounds(Bounds newBounds)
    {
        bounds = newBounds;
    }

    public float GetOrthographicSize()
    {
        return GetSize() + margin;
    }

    private float GetSize()
    {
        float size;
        if (bounds.size.x / bounds.size.y < camera.aspect)
        {
            size = bounds.size.y;
        }
        else
        {
            float levelAspect = (bounds.size.x / bounds.size.y);
            size = bounds.size.y / camera.aspect * levelAspect;
        }
        return size / 2;
    }
}
