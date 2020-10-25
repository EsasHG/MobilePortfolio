using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    #region fields
    [Tooltip("Layers considered as valid targets")]
    public LayerMask layerMasks;

    [Tooltip("maximum detection distance")]
    public float distance;

    /// <summary>
    ///  True if the raycaster is colliding with a collider
    /// </summary>
    private bool isColliding;

    /// <summary>
    /// Event when hovering a target and passes it as argument
    /// </summary>
    public UnityEvent<GameObject> hitTarget;

    /// <summary>
    /// Events sending info relative to the hit position or normal
    /// </summary>
    public UnityEvent<Vector3> hitPosition, hitAngle;

    /// <summary>
    /// Event trigggered when the user is no longer following a game object
    /// </summary>
    public UnityEvent stopHittingTarget;
    #endregion
    
    public void Raycast()
    {
        Ray ray = new Ray(transform.position, transform.forward*distance);
        Debug.DrawRay(transform.position, transform.forward*distance);

        RaycastHit hitInfo;

        bool hasHit = Physics.Raycast(ray, out hitInfo, distance, layerMasks);


        if (hasHit)
        {
            Debug.Log("Raycast! hit:" + hitInfo.collider.name);
            hitTarget?.Invoke(hitInfo.collider.gameObject);
            hitAngle?.Invoke(hitInfo.normal);
            hitPosition?.Invoke(hitInfo.point);
        }
        else if(isColliding)
        {
            stopHittingTarget?.Invoke();
        }

        if (isColliding != hasHit)
            isColliding = hasHit;


    }
    private void Update()
    {
        Raycast();
    }
}
