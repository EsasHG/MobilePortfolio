using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetectionTracker : MonoBehaviour
{
    public int FingerID;

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        for (int i = 0; i < touchCount; i++)
        {
            if(Input.GetTouch(i).fingerId == FingerID)
            {
                transform.position = Input.GetTouch(i).position;
                Debug.Log(Input.GetTouch(i).position);
            }
        }
    }
}
