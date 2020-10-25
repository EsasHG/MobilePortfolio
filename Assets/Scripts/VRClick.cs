using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VRClick : MonoBehaviour
{
    [SerializeField , Tooltip("Current object hovered over")]
    private GameObject hoveredObject;

    /// <summary>
    /// Notifies subscribers of a new hovered object
    /// </summary>
    public UnityEvent newHoveredObject;

    /// <summary>
    /// Notifies subscribers that the hovered object has been exited
    /// </summary>
    public UnityEvent hoveredObjectExited;

    public void ProcessHoveredObject(GameObject obj)
    {

        Debug.Log("Testing ProcessHovered!");
        if (hoveredObject != obj)
        {
            hoveredObject = obj;
            newHoveredObject.Invoke();
        }
    }

    public void StoppedHovering()
    {
        hoveredObject = null;
        hoveredObjectExited.Invoke();
    }

    public void PerformClick()
    {
        if (!hoveredObject) { return; }

        IPointerClickHandler clickHandler = hoveredObject.GetComponent<IPointerClickHandler>();
        clickHandler?.OnPointerClick(null);
    }
}
