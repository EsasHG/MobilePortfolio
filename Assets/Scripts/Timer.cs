using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float elapsedTime = 0.0f;

    public float duration = 1.0f;

    [Tooltip("Output the value as time or percentage")]
    public bool usePercentage;

    public UnityEvent<float> elapsedTimeUpdated;

    public UnityEvent completed;

    public float GetProgress(bool asPercentage = true)
    {
        float result;
        if (asPercentage)
            result = elapsedTime/duration;
        else
            result = elapsedTime;

        return Mathf.Clamp(result, 0, asPercentage? 1 : duration);
    }

    public IEnumerator PerformTimeCheck()
    {
        while (elapsedTime < duration)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;

            elapsedTimeUpdated?.Invoke(GetProgress(usePercentage));
        }
        completed?.Invoke();
    }
    public void StartTimer()
    {
        StopAllCoroutines();
        StartCoroutine(PerformTimeCheck());
    }

    public void ResetTime()
    {
        elapsedTime = 0;
        elapsedTimeUpdated?.Invoke(GetProgress(usePercentage));
    }

    public void RestartTimer()
    {
        ResetTime();
        StartTimer();
    }
}
