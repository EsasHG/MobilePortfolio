using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotator : MonoBehaviour
{

    public void SetLightYRotation(float inRot)
    {
        transform.rotation = Quaternion.Euler(0, inRot, 0);
    }
}
