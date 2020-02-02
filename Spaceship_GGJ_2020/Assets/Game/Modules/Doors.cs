using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : ShipModule
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject colliders = null;
    [SerializeField] private GameObject warning = null;
    [Space]
    [SerializeField] private float delayTime = 1f;

    private float timer = 0;

    protected override void Update()
    {
        base.Update();

        if (IsWorking)
        {
            timer = 0;
            colliders.SetActive(false);
            animator.SetBool("Open", true);
            warning.SetActive(false);
        }
        else
        {
            timer += Time.deltaTime;
            if(timer > delayTime)
            {
                colliders.SetActive(true);
                animator.SetBool("Open", false);
                warning.SetActive(false);
            }
            else
            {
                warning.SetActive(true);
            }
        }

    }
}
