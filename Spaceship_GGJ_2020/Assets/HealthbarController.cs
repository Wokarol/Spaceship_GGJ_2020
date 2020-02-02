using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    Func<float> getter;
    private float lastValue;

    private void Update()
    {
        float v = getter();

        if(v != lastValue)
        {
            rectTransform.anchorMax = new Vector2(v, 1);
        }

        lastValue = v;
    }

    public void Bind(Func<float> getter)
    {
        this.getter = getter;
    }
}
