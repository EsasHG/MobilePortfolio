using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRayCast : MonoBehaviour
{

    public Camera usedCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (!usedCamera)
            usedCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = usedCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction,Color.red,10.0f);
        Debug.Log("Ray!" + ray.origin.ToString());
    }
}
