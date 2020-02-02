using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TorpedoLoader : MonoBehaviour
{
    [SerializeField] private Transform TheTorpedo = null;
    [SerializeField] private Transform TheStart = null;
    [SerializeField] private Transform TheLaunch = null;
    [Space]
    [SerializeField] private float slidingTime = 5f;

    private Animator animator;
    private Action callback;
    private bool isLoading;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadTorpedo(Action callback)
    {
        if (isLoading)
            return;
        animator.SetTrigger("Load");
        this.callback = callback;
        isLoading = true;
    }

    public void LoadedTorpedo()
    {
        isLoading = false;
        TheTorpedo.gameObject.SetActive(true);
        TheTorpedo.position = TheStart.position;
        TheTorpedo.DOMove(TheLaunch.position, slidingTime);
    }
}
