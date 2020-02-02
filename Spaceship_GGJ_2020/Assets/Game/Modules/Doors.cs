using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : ShipModule
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject colliders = null;

    protected override void Update()
    {
        base.Update();
        colliders.SetActive(!IsWorking);
        animator.SetBool("Open", IsWorking);
    }
}
