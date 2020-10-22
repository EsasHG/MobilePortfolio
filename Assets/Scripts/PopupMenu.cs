using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMenu : MonoBehaviour
{
    private float openY = 0;
    public float closedY = 0;

    private void Start()
    {
        openY = transform.localPosition.y;
        transform.localPosition = new Vector3(0, closedY, 0);
    }
    public void Open()
    {
        transform.DOLocalMoveY(openY, 0.5f);
    }
    public void Close()
    {
        transform.DOLocalMoveY(closedY, 0.5f);
    }

}
