using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectSizeSetter : CamraSizeHandler
{
    public override void SetSize(float size)
    {
        SetSizeDirect(size);
    }

}
