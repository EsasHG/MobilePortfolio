using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRToggle : MonoBehaviour
{
    public bool isOn;
    [SerializeField]
    private GameObject checkmark;

    public UnityEvent<bool> toggled;
    // Start is called before the first frame update
    void Start()
    {
        checkmark.SetActive(isOn);
    }


    public void Toggle()
    {
        isOn = !isOn;
        checkmark.SetActive(isOn);
        toggled?.Invoke(isOn);
    }
}
