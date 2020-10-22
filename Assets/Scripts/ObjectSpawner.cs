using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private GameObject spawnedObject;

    public List<GameObject> models = new List<GameObject>();
    int modelIndex = 0;

    private bool isSpawned = false;

    public void SpawnObject(Vector3 spawnPos)
    {
        spawnedObject = Instantiate(models[modelIndex], spawnPos, Quaternion.identity);
        isSpawned = true;
    }

    public void MoveObject(Vector3 newPos)
    {
        if(isSpawned)
            spawnedObject.transform.position = newPos;
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
