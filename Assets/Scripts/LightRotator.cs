using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class LightRotator : MonoBehaviour
{

    bool rotateLightsOnUpdate = false;
    float currentRot = 0;
    public float speed = 50;
    public void SetLightYRotation(float inRot)
    {
        currentRot = inRot;
        transform.rotation = Quaternion.Euler(0, currentRot, 0);
    }

    public void ToggleRotation()
    {
        rotateLightsOnUpdate = !rotateLightsOnUpdate;
    }

    private void Update()
    {
        if(rotateLightsOnUpdate)
        {
            currentRot += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, currentRot, 0);
        }
    }
}
