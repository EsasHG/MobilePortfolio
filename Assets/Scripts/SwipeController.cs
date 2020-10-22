///modified from https://forum.unity.com/threads/simple-swipe-and-tap-mobile-input.376160/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeController : MonoBehaviour
{
    public UnityEvent swipeRight;
    public UnityEvent swipeLeft;

    public float maxDragTime = 0.3f;

    private Vector3 firstPosition;   //First touch position
    private Vector3 lastPosition;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private float currentDragTime = 0.0f;


    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                currentDragTime = 0.0f;
                firstPosition = touch.position;
                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                currentDragTime += Time.deltaTime;
                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                if (currentDragTime >= maxDragTime)
                    return;

                lastPosition = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lastPosition.x - firstPosition.x) > dragDistance || Mathf.Abs(lastPosition.y - firstPosition.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lastPosition.x - firstPosition.x) > Mathf.Abs(lastPosition.y - firstPosition.y)*2)
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lastPosition.x > firstPosition.x))  //If the movement was to the right)
                        {   //Right swipe
                            swipeRight?.Invoke();
                        }
                        else
                        {   //Left swipe
                            swipeLeft?.Invoke();
                        }
                    }
                }
            }
        }
    }
}
