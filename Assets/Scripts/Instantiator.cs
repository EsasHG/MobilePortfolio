using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject Prefab;
    private GameObject CurrentInstance;

    public void Instantiate(GameObject prefab)
    {
        CurrentInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
    }

    public void DestroyCurrentInstance()
    {
        if (CurrentInstance)
            Destroy(CurrentInstance);
    }

}
