using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{
    [Tooltip("The controller of the reticule")]
    public Transform controller;

    [SerializeField, Tooltip("Prevents the automatic positioning of the reticule")]
    private bool overrideAutomatedUpdate;

    [Tooltip("Distance from the hit position")]
    public float distanceFromHit = 0.05f;

    [Tooltip("reticule Distance from this transform")]
    public float restingDistance = 2.0f;

    public bool InvertForward;

    public void OverrideAutomatedUpdate(bool value)
    {
        overrideAutomatedUpdate = value;
    }

    public void AutoPositionAndOrientation()
    {
        Debug.Log("AutoPosAndRot");
        transform.position = controller.position + controller.forward * restingDistance;
        transform.forward = (InvertForward ? -1 : 1) * controller.forward;
    }

    public void SetForward(Vector3 forward)
    {
        Debug.Log("SetForward");

        transform.forward = (InvertForward ? -1 : 1) * forward;
    }

    public void SetPosition(Vector3 position)
    {
        Debug.Log("SetPos");
        transform.position = position + (InvertForward ? -1 : 1) * transform.forward * distanceFromHit;
    }

    public void Update()
    {
        if (!overrideAutomatedUpdate)
            AutoPositionAndOrientation();
    }

}
