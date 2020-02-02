using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructionController : MonoBehaviour
{
    private bool isBroken { get; set; }

    public bool IsBroken
    {
        get => isBroken;
        set
        {
            if(isBroken != value)
            {
                isBroken = value;
                UpdateState();
            }
        }
    }

    protected abstract void UpdateState();
}
