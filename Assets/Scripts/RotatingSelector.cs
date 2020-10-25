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
    public float modelRotateSpeed = 50;
    private float degreeOffset = 0;
    public Transform RotateParent = null;

    private bool rotateModel = false;

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
    private void Update()
    {
        if (rotateModel)
            RotateCurrentModel();
    }
    public void Next()
    {

        Debug.Log("Next Model!");
        if (modelIndex >= models.Count - 1)
            ChangeModel(0);
        else
            ChangeModel(modelIndex + 1);
    }

    public void Previous()
    {
        Debug.Log("Prev Model!");

        if (modelIndex <= 0)
            ChangeModel(models.Count - 1);
        else
            ChangeModel(modelIndex - 1);
    }

    public void ChangeModel(int index)
    {
        Debug.Log("Change Model!");

        int moveIndex = index - modelIndex;
        RotateParent.DOKill();
        CurrentTargetAngle += degreeOffset * moveIndex;
        modelIndex = index;
        RotateParent.DORotate(new Vector3(0, CurrentTargetAngle, 0), rotateSpeed);
        modelChanged?.Invoke(models[modelIndex]);
    }

    public void RotateCurrentModel()
    {
        Vector3 rot = models[modelIndex].transform.localRotation.eulerAngles;
        models[modelIndex].transform.localRotation = Quaternion.Euler(rot.x, rot.y + modelRotateSpeed * Time.deltaTime, rot.z);
    }

    public void ToggleRotation()
    {
        rotateModel = !rotateModel;
    }
}
