using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrbitCameraDesktop : OrbitCamera
{
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
    private void OnEnable()
    {
        this.enabled = false;
    }
#endif
    public override void UserInput()
    {
        if (Input.GetMouseButton(0))
        {
            PerformRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        if (Input.GetMouseButton(1))
        {
            PerformPan(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            PerformZoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}
