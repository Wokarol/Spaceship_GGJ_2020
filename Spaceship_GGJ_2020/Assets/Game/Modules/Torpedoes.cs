using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Torpedoes : ShipModule
{
    [SerializeField] private TorpedoLoader loader;
    [SerializeField] private float damagePerTorpedo = 0.1f;
    [SerializeField] private float speed;

    private Tween tween;

    protected override void Update()
    {
        base.Update();
        int scale = IsWorking ? 1 : 0;

        loader.SetTimeScale(scale);
    }

    public override void Interact()
    {
        if (!IsWorking)
            return;

        Debug.Log("I've been interacted with");

        if (loader.TheTorpedoInBay)
        {
            Transform theTorpedo = loader.TheTorpedo;
            Animator animator = theTorpedo.GetComponent<Animator>();

            loader.TorpedoTaken();

            animator.SetBool("Flying", true);
            theTorpedo.DOMove(theTorpedo.position + (Vector3.right * 100), 1 / speed)
                .OnComplete(() => { 
                    animator.SetBool("Flying", false); 
                    loader.LoadTorpedo();
                    director.Enemy.Damage(damagePerTorpedo);
                });
        }
    }
}
