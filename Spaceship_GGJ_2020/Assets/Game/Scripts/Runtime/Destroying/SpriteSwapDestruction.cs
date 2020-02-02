using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapDestruction : DestructionController
{
    [SerializeField] private Sprite brokenSprite;
    [SerializeField] private Animator optionalAnimatorToStop;

    private SpriteRenderer renderer;

    private Sprite lastSprite = null;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    protected override void UpdateState()
    {
        if (IsBroken)
        {
            lastSprite = renderer.sprite;
            renderer.sprite = brokenSprite;
            if (optionalAnimatorToStop)
                optionalAnimatorToStop.enabled = false;
        }
        else
        {
            if (lastSprite != null)
            {
                renderer.sprite = lastSprite;
                if (optionalAnimatorToStop)
                    optionalAnimatorToStop.enabled = true;
            }
        }
    }
}
