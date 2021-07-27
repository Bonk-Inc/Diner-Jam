using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimator : PositionChanger
{

    private Coroutine moveRoutine;

    [SerializeField]
    private float smoothTime;

    public bool CurrentlyMoving
    {
        get;
        private set;
    }

    public override void MoveTo(Vector3 newPosition)
    {
        if (CurrentlyMoving && moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }

        moveRoutine = StartCoroutine(AnimateTowards(newPosition, SetPositionDirect));
    }

    public override void MoveToLocal(Vector3 newPosition)
    {
        if (CurrentlyMoving && moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }

        moveRoutine = StartCoroutine(AnimateTowards(newPosition, SetLocalPositionDirect));
    }

    private IEnumerator AnimateTowards(Vector3 position, Action<Vector3> setPosition)
    {
        CurrentlyMoving = true;
        while (transform.position != position)
        {
            Vector3 vlocity = Vector3.zero;
            setPosition(Vector3.SmoothDamp(transform.position, position, ref vlocity, smoothTime));
            yield return null;
        }
        transform.position = position;
        CurrentlyMoving = false;
    }

}
