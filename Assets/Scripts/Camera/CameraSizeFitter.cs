using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeFitter : MonoBehaviour
{

    [SerializeField]
    private OrthographicCameraSizeCalculator sizeCalculator;

    [SerializeField]
    private LevelBoundsCalculator boundsCalculator;

    [SerializeField]
    private CamraSizeHandler sizeHandler;

    // Start is called before the first frame update
    private void Start()
    {
        Bounds bounds = boundsCalculator.currentLevelBounds;
        sizeCalculator.SetBounds(bounds);
        float size = sizeCalculator.GetOrthographicSize();
        CenterCamera(bounds);
        sizeHandler.SetSize(size);
    }

    private void CenterCamera(Bounds levelBounds)
    {
        Transform cameraTransform = sizeHandler.Camera.transform;
        Vector3 newCameraPosition = levelBounds.center;
        newCameraPosition.z = cameraTransform.position.z;
        cameraTransform.position = newCameraPosition;
    }

}
