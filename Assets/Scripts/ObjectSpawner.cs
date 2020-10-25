using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> models = new List<GameObject>();
    int modelIndex = 0;

    private bool isSpawned = false;

    public void Start()
    {
        foreach (GameObject model in models)
            model.SetActive(false);
    }

    public void SpawnObject(Vector3 spawnPos)
    {
        models[modelIndex].transform.position = spawnPos;
        models[modelIndex].SetActive(true);
        isSpawned = true;
    }

    public void MoveObject(Vector3 newPos)
    {
        if(isSpawned)
            models[modelIndex].transform.position = newPos;
    }

    public void EndMove()
    {
        isSpawned = false;
    }
    
    public void SetCurrentSpawnable(int newModelIndex)
    {
        if (newModelIndex  < 0 || newModelIndex  > models.Count - 1)
        {
            Debug.LogError("New index larger than the amount of models!");
        }
        else
            modelIndex = newModelIndex;

    }
}
