using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PositionChanger : MonoBehaviour
{
    public abstract void MoveTo(Vector3 newPosition);
    public abstract void MoveToLocal(Vector3 newPosition);

    public virtual void Move(Vector3 value) {
        MoveTo(transform.position + value);   
    }

    public virtual void MoveLocal(Vector3 value)
    {
        MoveToLocal(transform.localPosition + value);
    }

    public virtual void SetPositionDirect(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public virtual void SetLocalPositionDirect(Vector3 newPosition)
    {
        transform.localPosition = newPosition;
    }
}
