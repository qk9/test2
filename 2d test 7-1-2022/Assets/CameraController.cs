using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomStepSize;
    void LateUpdate()
    {
        Vector2 conversionFactor = Camera.main.sensorSize.normalized;
        float zoomStep = zoomStepSize * Input.mouseScrollDelta.y;
        Camera.main.sensorSize += new Vector2(zoomStep * conversionFactor.x, zoomStep * conversionFactor.y);
    }
}
