using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script created for you to optimisse
/// </summary>
public class InRangeCheck : MonoBehaviour
{
    [Tooltip("The list of game objects to check if they are in range")]
    public List<GameObject> targets;

    [Tooltip("The maximum allowed distance to be in range")]
    public float rangeDistance;
    
    [Tooltip("Is the object within range")]
    public bool allInRange;

    private Camera mainCam;

    void Start()
    {
        if(!mainCam)
            mainCam = Camera.main;
    }

    void Update()
    {
        allInRange = true;
        int i = targets.Count -1;
        while (i >= 0)
        {
            if (targets[i] && !IsInRange(targets[i].transform))
            {
                allInRange = false;
            }
            i--;
        }
    }
    public bool IsInRange(Transform target)
    {
        return Vector3.SqrMagnitude(target.position - mainCam.transform.position) < (rangeDistance * rangeDistance);
    }
}