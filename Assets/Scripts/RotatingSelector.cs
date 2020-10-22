using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotatingSelector : MonoBehaviour
{
    [SerializeField]
    List<GameObject> models = new List<GameObject>();

    public UnityEvent<GameObject> modelChanged;
    int modelIndex = 0;

    public float radius = 2.0f;
    public float rotateSpeed = 0.3f;
    private float degreeOffset = 0;
    public Transform RotateParent = null;

    private DOTween rotationTween;
    float CurrentTargetAngle = 0.0f;
    private void Start()
    {
        RotateParent.position += Vector3.forward * radius;
        int numberOfModels = models.Count;
        degreeOffset = 360.0f / numberOfModels;
        for (int i = 0; i < numberOfModels; i++)
        {
            models[i].transform.SetParent(RotateParent);
            RotateParent.Rotate(new Vector3(0, degreeOffset, 0));
        }
        ChangeModel(0);
    }

    public void Next()
    {
        if (modelIndex == models.Count - 1)
            ChangeModel(0);
        else
            ChangeModel(modelIndex + 1);
    }

    public void Previous()
    {
        if (modelIndex == 0)
            ChangeModel(models.Count - 1);
        else
            ChangeModel(modelIndex - 1);
    }

    public void ChangeModel(int index)
    {
        int moveIndex = index - modelIndex;
        RotateParent.DOKill();
        CurrentTargetAngle += degreeOffset * moveIndex;
        modelIndex = index;
        RotateParent.DORotate(new Vector3(0, CurrentTargetAngle, 0), rotateSpeed);
        modelChanged?.Invoke(models[modelIndex]);
    }   
}
