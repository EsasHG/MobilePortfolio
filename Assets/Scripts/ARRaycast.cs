using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycast : MonoBehaviour
{
    public ARRaycastManager manager;
    private List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();

    public UnityEvent<Vector3> hitDetected;
    public UnityEvent<Vector3> hitMoved;
    public UnityEvent hitEnd;

    // Update is called once per frame
    public void Update()
    {
        if(Input.touchCount > 0)
        {
            PerformARRaycast();
        }
    }

    public void PerformARRaycast()
    {



        /*
         //for not raytracing through UI
         if (Input.touchCount > 0 && !EventSystem.current.currentSelectedGameObject)

         */
        if (manager.Raycast(Input.GetTouch(0).position,raycastHitList,TrackableType.All))
        {
            Vector3 hitPosition = raycastHitList[0].pose.position;

            string result = "";
            switch(Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    result = "Touch Began!" + hitPosition.ToString();
                    hitDetected?.Invoke(hitPosition);
                    break;
                case TouchPhase.Moved:
                    result = "Touch Moved!" + hitPosition.ToString();
                    hitMoved?.Invoke(hitPosition);
                    break;
                case TouchPhase.Ended:
                    result = "Touch Ended!" + hitPosition.ToString();
                    hitEnd?.Invoke();
                    break;
                default: break;
            }
        }
        raycastHitList.Clear();
    }
}
